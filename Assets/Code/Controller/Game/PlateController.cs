using UnityEngine;
using System.Collections;

public class PlateController : LogicController
{
    public enum PlateState
    {
        Ready,
        Drop,
        Broke,
        Hold
    }

    //盘子中心点的位置
    public Transform PlatePoint;

    private Transform GroundPoint;

    public Vector3 DropDir = new Vector3(0, -1, 0);
    public float DropSpeed = 0.8f;

    public PlateState _state;

    private Animator _anim;

    private bool _isHold;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.PlateEvent, OnPlate);

        PlatePoint = this.transform.Find("LockPoint");

        GroundPoint = GameObject.Find("GroundPoint").transform;

        _state = PlateState.Ready;

        _anim = this.gameObject.GetComponent<Animator>();

        _isHold = false;
    }

    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);

        switch (_state)
        {
            case PlateState.Drop:
                {
                    this.transform.position += DropSpeed * DropDir * dt;

                    if (this.transform.position.y < GroundPoint.position.y)
                    {
                        _state = PlateState.Broke;

                        _anim.SetBool("isbroke",true);
                    }
                }
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(_state == PlateState.Drop)
        {
            if(collision.gameObject.name == "man_hand")
            {
                _state = PlateState.Hold;

                _anim.SetBool("ishold", true);

                this.transform.parent = collision.gameObject.transform;

                this.transform.localPosition = Vector3.zero;

                _isHold = true;
            }


        }
    }

    public void OnPlate(string parm)
    {
        Debug.Log("plate");
    }

    public override void Reset()
    {
        if(!_isHold)
        {
            base.Reset();

            if(_anim != null)
                _anim.SetBool("isbroke", false);
        }
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();

        if (_state == PlateState.Ready)
        {
            _state = PlateState.Drop;
        }
    }
}
