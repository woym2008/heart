using UnityEngine;
using System.Collections;

public class SignalController : LogicController
{
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnSignal);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public void OnSignal(string parm)
    {
        Debug.Log("Signal");
    }
}
