using UnityEngine;
using System.Collections;

public class KeyController : LogicController
{
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnKey);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public void OnKey(string parm)
    {
        Debug.Log("key");
    }
}
