using UnityEngine;
using System.Collections;

public class HeadController : LogicController
{
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnHead);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public void OnHead(string parm)
    {
        Debug.Log("HeadController");
    }
}
