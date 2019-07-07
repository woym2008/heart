using UnityEngine;
using System.Collections;

public class KeyController : LogicController
{
    public enum KeyState
    {
        Ready,
        Drop,
        Ground,
        OnPlate,
        Disappear
    }

    private Transform GroundPoint;

    public Vector3 DropDir = new Vector3(0,-1,0);
    public float DropSpeed = 0.8f;

    public KeyState _state;

    SpriteRenderer _renderer;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.KeyEvent, OnKey);

        GroundPoint = GameObject.Find("GroundPoint").transform;

        _state = KeyState.Ready;

        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);

        switch(_state)
        {
            case KeyState.Drop:
                {
                    this.transform.position += DropSpeed * DropDir * dt;

                    if(this.transform.position.y < GroundPoint.position.y)
                    {
                        _state = KeyState.Ground;
                    }
                }
                break;
        }
    }

    public void OnKey(string param)
    {
        Debug.Log("key");

        if(param == "used")
        {
            _state = KeyState.Disappear;

            EventManager.GetInstance().Fire(ConfigContext.HeadEvent, "open");
        }
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();

        if(_state == KeyState.Ready)
        {
            _state = KeyState.Drop;

            _renderer.sortingOrder = 7;
        }
    }

    public override void Reset()
    {
        if(_state != KeyState.Disappear)
        {
            this.transform.parent = null;

            base.Reset();

            _state = KeyState.Ready;

            _renderer.sortingOrder = 5;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_state == KeyState.Drop)
        {
            if(collision.gameObject.name == "Plate")
            {
                _state = KeyState.OnPlate;

                var plate = collision.gameObject.GetComponent<PlateController>();
                if(plate != null)
                {
                    this.transform.parent = plate.PlatePoint;
                    this.transform.localPosition = Vector3.zero;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_state == KeyState.Drop)
        {
            if (collision.gameObject.name == "Plate")
            {
                _state = KeyState.OnPlate;

                var plate = collision.gameObject.GetComponent<PlateController>();
                if (plate != null)
                {
                    this.transform.parent = plate.PlatePoint;
                    this.transform.localPosition = Vector3.zero;
                }
            }
        }
    }
}
