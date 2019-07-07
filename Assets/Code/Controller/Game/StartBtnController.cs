using UnityEngine;
using System.Collections;

public class StartBtnController : LogicController
{
    private void Start()
    {
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
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

    public override void Reset()
    {
        //base.Reset();
    }
}
