using UnityEngine;
using System.Collections;

public class WomanController : LogicController
{
    public enum WomanState
    {
        WaitHeart,
        Angry,
        Happy,
        Kill,
    }

    Animator _Animator;

    WomanState _state;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.WomanEvent, OnWoman);

        _Animator = this.gameObject.GetComponent<Animator>();

        _state = WomanState.WaitHeart;
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnWoman(string param)
    {
        Debug.Log("onwoman");

        if(param == "noheart")
        {
            Debug.Log("OnWoman noheart");
            if(_state == WomanState.WaitHeart)
            {
                _state = WomanState.Angry;

                PlayDie();
            }
        }

        if(param == "givekey")
        {
            Debug.Log("OnWoman givekey");

            EventManager.GetInstance().Fire(ConfigContext.HeadEvent,"open");

            EventManager.GetInstance().Fire(ConfigContext.KeyEvent, "disappear");

            PlayDie();
        }

        if(param == "findheart")
        {
            //_Animator
            PlayWin();
        }
    }

    void PlayDie()
    {
        ProcessManager.GetInstance().SetState(new ReadyProcess());
    }

    void PlayWin()
    {
        ;
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
