using UnityEngine;
using System.Collections;

public class HeartController : LogicController
{
    private Transform GroundPoint;

    public float _movedis;

    public float DropSpeed = 0.1f;
    public Vector3 DropDir = new Vector3(0,-1,0);
    public float RotateSpeed = 90;

    public bool IsRedHeart = false;

    public enum State
    {
        Ready,
        Drop,
        OnPlate,
        Ground
    }

    State _state;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.HeartEvent, OnHeart);

        GroundPoint = GameObject.Find("GroundPoint").transform;
        var offset = this.transform.position.y- GroundPoint.transform.position.y;

        _movedis = Mathf.Abs(offset);

        _state = State.Ready;
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);

        switch (_state)
        {
            case State.Drop:
                {
                    this.transform.position += DropSpeed * DropDir * dt;

                    this.transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * RotateSpeed);

                    if (this.transform.position.y < (_oriPosition.y - _movedis))
                    {
                        _state = State.Ground;
                    }


                }
                break;
        }
    }

    public void OnHeart(string param)
    {
        Debug.Log("OnHeart");
        if(param == "drop")
        {
            _state = State.Drop;
        }

        if(param == "enterover" && IsRedHeart)
        {
            if(_state == State.OnPlate)
            {
                EventManager.GetInstance().Fire(ConfigContext.WomanEvent, "findheart");
            }
            else if(_state == State.Ground)
            {
                EventManager.GetInstance().Fire(ConfigContext.WomanEvent, "noheart");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_state == State.Drop && IsRedHeart)
        {
            if (collision.gameObject.name == "Plate")
            {
                _state = State.OnPlate;

                var plate = collision.gameObject.GetComponent<PlateController>();
                if (plate != null)
                {
                    this.transform.parent = plate.PlatePoint;
                    this.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_state == State.Drop && IsRedHeart)
        {
            if (collision.gameObject.name == "Plate")
            {
                _state = State.OnPlate;

                var plate = collision.gameObject.GetComponent<PlateController>();
                if (plate != null)
                {
                    this.transform.parent = plate.PlatePoint;
                    this.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    public override void Reset()
    {
        base.Reset();

        _state = State.Ready;
    }
}
