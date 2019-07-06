using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ManController : LogicController
{
     List<Transform> _points = new List<Transform>();

    Queue<Transform> _currentPoints = new Queue<Transform>();

    public float Speed = 1.0f;
    public Vector3 _currentDir;

    private void Start()
    {
        CollectPath();
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
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);

        MoveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
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

    public override void StopUpdate(float dt)
    {
        base.StopUpdate(dt);
    }
}
