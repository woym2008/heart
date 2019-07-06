using UnityEngine;
using System.Collections;

public class StartBtnController : LogicController
{
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnStart);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public void OnStart(string parm)
    {
        Debug.Log("Start");
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();
    }
    public override void OnStopInput()
    {
        base.OnStopInput();

        ProcessManager.GetInstance().SetState(new RunProcess());
    }
}
