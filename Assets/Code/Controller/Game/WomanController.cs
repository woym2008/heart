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

    public DialogController _Dialog;

    public WhiteController _white;

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

                //PlayDie();
            }

            _Dialog.Play("anim_dialog_heart");

            StartCoroutine(ReadyDoubt());
        }

        if(param == "givekey")
        {
            Debug.Log("OnWoman givekey");

            //EventManager.GetInstance().Fire(ConfigContext.HeadEvent,"open");

            //EventManager.GetInstance().Fire(ConfigContext.KeyEvent, "disappear");

            _Dialog.Play("anim_dialog_heart");

            StartCoroutine(ReadyThinkUseKey());
            //PlayDie();
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

    public override void Reset()
    {
        base.Reset();

        _Dialog.Play("anim_dialog_need");
    }

    IEnumerator ReadyDoubt()
    {
        yield return new WaitForSeconds(2);

        _Dialog.Play("anim_dialog_doubt");

        StartCoroutine(ReadyAngry());
    }

    IEnumerator ReadyAngry()
    {
        yield return new WaitForSeconds(2);

        _Dialog.Play("anim_dialog_angry");

        StartCoroutine(ReadyKill());
    }

    IEnumerator ReadyKill()
    {
        yield return new WaitForSeconds(2);

        _white.Shine();

        yield return new WaitForSeconds(0.75f);

        EventManager.GetInstance().Fire(ConfigContext.ManEvent, "die");

        StartCoroutine(ReadyReset());
    }

    IEnumerator ReadyReset()
    {
        yield return new WaitForSeconds(2);


        PlayDie();
    }
    //------------------------------------
    IEnumerator ReadyThinkUseKey()
    {
        yield return new WaitForSeconds(1);

        //_Dialog.Play("anim_dialog_usekey");

        yield return new WaitForSeconds(1);

        EventManager.GetInstance().Fire(ConfigContext.HeadEvent, "open");

        EventManager.GetInstance().Fire(ConfigContext.KeyEvent, "disappear");

        StartCoroutine(ReadyDoubt());
    }
    //------------------------------------
    IEnumerator ReadyWin()
    {
        yield return new WaitForSeconds(1);
    }
}
