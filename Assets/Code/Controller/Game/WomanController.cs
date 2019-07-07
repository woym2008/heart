using UnityEngine;
using System.Collections;

public class WomanController : LogicController
{
    public enum WomanState
    {
        WaitHeart,
        Angry,
        Kill,
    }

    Animator _Animator;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent, OnWoman);

        _Animator = this.gameObject.GetComponent<Animator>();
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnWoman(string param)
    {
        Debug.Log("OnWoman");

        if(param == "NoHeart")
        {

        }

        if(param == "GiveKey")
        {

        }

        if(param == "FindHeart")
        {
            //_Animator
        }
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();
    }

    public override void OnStopInput()
    {
        base.OnStopInput();
    }

    public void OnKillMan()
    {
        ;
    }

    public void OnKillManFinish()
    {
        ;
    }

    public void OnFinishGame()
    {
        ;
    }
}
