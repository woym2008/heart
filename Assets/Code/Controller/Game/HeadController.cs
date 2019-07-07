using UnityEngine;
using System.Collections;

public class HeadController : LogicController
{
    public GameObject SignalObj;

    Animator _anim;

    bool _isOpen;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.HeadEvent, OnHead);

        _isOpen = false;

        _anim = this.gameObject.GetComponent<Animator>();
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnHead(string param)
    {
        Debug.Log("HeadController");
        if(param == "open" && !_isOpen)
        {
            //_anim.Play("open");
            SignalObj.SetActive(true);

            _isOpen = true;

            if (_anim != null)
                _anim.SetBool("isopen", true);

            EventManager.GetInstance().Fire(ConfigContext.SignalEvent,"enable");
        }
    }

    public override void Reset()
    {
        //base.Reset();
    }
}
