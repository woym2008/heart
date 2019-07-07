using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LogicController : MonoBehaviour, ILogicScript
{
    protected Vector3 _oriPosition;
    protected Vector3 _oriScale;
    protected Quaternion _oriRotation;
    private void Awake()
    {
        Initialize();
    }
    private void Start()
    {

    }

    public void Update()
    {
        //if(Input.GetKeyDown(KeyCode.D))
        {
            //ProcessManager.GetInstance().SetState(new ReadyProcess());
        }

    }

    public virtual void Initialize()
    {
        Debug.Log("LogicController Initialize " +  gameObject.name);
        LogicScriptManager.GetInstance().AddLogicScript(this);

        _oriPosition = this.transform.position;
        _oriScale = this.transform.localScale;
        _oriRotation = this.transform.rotation;
    }

    public virtual void ActiveUpdate(float dt)
    {
    }

    public virtual void StopUpdate(float dt)
    {
    }

    public virtual void EnterActive()
    {
        ;
    }

    public virtual void OnActiveInput()
    {
        Debug.Log("OnInput LogicController");
    }

    public virtual void EnterStop()
    {
        ;
    }



    public virtual void OnStopInput()
    {
        Debug.Log("OnStop LogicController");
    }

    public virtual void Reset()
    {
        this.transform.position = _oriPosition;
        this.transform.rotation = _oriRotation;
        this.transform.localScale = _oriScale;
    }
}
