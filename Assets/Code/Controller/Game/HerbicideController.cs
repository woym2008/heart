using UnityEngine;
using System.Collections;

public class HerbicideController : LogicController
{
    Animator _anim;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnHerbicide);
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnHerbicide(string param)
    {
    }
}
