using UnityEngine;
using System.Collections;

public class PlateController : LogicController
{
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnPlate);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public override bool Equals(object other)
    {
        return base.Equals(other);
    }

    public void OnPlate(string parm)
    {
        Debug.Log("plate");
    }
}
