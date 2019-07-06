using UnityEngine;
using System.Collections;

public class FlowerController : LogicController
{
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent,OnFlower);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public void OnFlower(string parm)
    {
        Debug.Log("FlowerController");
    }
}
