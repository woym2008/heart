using UnityEngine;
using System.Collections;

public class SignalController : LogicController
{
    bool _isUsed = false;

    private void Start()
    {
        //EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnSignal);

        _isUsed = false;
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnSignal(string parm)
    {
        Debug.Log("Signal");
    }

    public override void Reset()
    {
        //base.Reset();
        _isUsed = false;
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();

        _isUsed = true;

        EventManager.GetInstance().Fire(ConfigContext.HerbicideEvent, "use");

    }
}
