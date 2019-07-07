using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManController : LogicController
{
     List<Transform> _points = new List<Transform>();

    Queue<Transform> _currentPoints = new Queue<Transform>();

    Animator _anim;

    public Camera _camera;
    private Vector3 _cameraOriLocalPos;

    public Transform HandPoint;
    public Transform HandLeftPos;
    public Transform HandRightPos;

    public float Speed = 1.0f;
    public Vector3 _currentDir;

    public GameObject Hole;

    private void Start()
    {
        CollectPath();

        _anim = this.gameObject.GetComponent<Animator>();

        _anim.SetBool("isleft", true);

        EventManager.GetInstance().AddListener(ConfigContext.ManEvent, OnMan);

        _cameraOriLocalPos = _camera.transform.localPosition;
    }
    public override void EnterActive()
    {
        base.EnterActive();

        foreach(var point in _points)
        {
            _currentPoints.Enqueue(point);
        }

        var currentpoint = _currentPoints.Peek();
        _currentDir = (currentpoint.transform.position - this.transform.position).normalized;

        Reset();

        _anim.SetBool("isleft", true);
        _anim.SetBool("iswalk", true);

        _camera.transform.localPosition = _cameraOriLocalPos;
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);

        MoveUpdate(dt);
    }

    public void OnMan(string param)
    {
        if(param == "die")
        {
            Hole.SetActive(true);

            _anim.SetBool("iswalk", false);
        }
    }

    private void CollectPath()
    {
        var paths = GameObject.Find("ManPath");
        if(paths != null)
        {
            var count = paths.transform.childCount;
            for(int i = 0; i<count; ++i)
            {
                var c = paths.transform.GetChild(i);
                _points.Add(c);
            }
        }
    }

    private void MoveUpdate(float dt)
    {
        if(_currentPoints.Count > 0)
        {
            var currentpoint = _currentPoints.Peek();

            var newpoint = this.transform.position + Speed * _currentDir;

            var nowdir = (currentpoint.transform.position - newpoint).normalized;

            var resoult = Vector3.Dot(nowdir, _currentDir);
            if (resoult < 0)
            {
                _currentPoints.Dequeue();
                if (_currentPoints.Count > 0)
                {
                    currentpoint = _currentPoints.Peek();

                    _currentDir = (currentpoint.transform.position - this.transform.position).normalized;

                    newpoint = this.transform.position + Speed * _currentDir;

                    this.transform.position = newpoint;

                    if(_currentDir.x < 0)
                    {
                        //left
                        _anim.SetBool("isleft", true);
                        HandPoint.localPosition = HandLeftPos.localPosition;
                    }
                    else
                    {
                        //right
                        _anim.SetBool("isleft", false);
                        HandPoint.localPosition = HandRightPos.localPosition;
                    }
                }
                else
                {
                    //finish;
                    ProcessManager.GetInstance().SetState(new OverProcess());
                }
            }
            else
            {
                this.transform.position = newpoint;
            }
        }

    }

    public float CameraSpeed = 0.5f;
    public override void StopUpdate(float dt)
    {
        base.StopUpdate(dt);

        if(Input.GetKey(KeyCode.A))
        {
            _camera.transform.Translate(CameraSpeed * dt * new Vector3(-1, 0, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            _camera.transform.Translate(CameraSpeed * dt * new Vector3(1, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            _camera.transform.Translate(CameraSpeed * dt * new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            _camera.transform.Translate(CameraSpeed * dt * new Vector3(0, -1, 0));
        }
    }

    public override void Reset()
    {
        base.Reset();

        if(_anim!=null)
        {
            _anim.SetBool("isleft", true);
            _anim.SetBool("iswalk", false);

            HandPoint.localPosition = HandLeftPos.localPosition;
        }

        Hole.SetActive(false);
    }
}
