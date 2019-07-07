using UnityEngine;
using System.Collections;

public class HerbicideController : LogicController
{
    Animator _anim;

    bool _isEnable = false;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.HerbicideEvent, OnHerbicide);

        _isEnable = false;

        _anim = this.gameObject.GetComponent<Animator>();
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnHerbicide(string param)
    {
        if(param == "use" && !_isEnable)
        {
            _isEnable = true;
            _anim.SetBool("enable",true);
            StartCoroutine(WaitKill());
        }
    }

    public IEnumerator WaitKill()
    {
        yield return new WaitForSeconds(0.5f);

        EventManager.GetInstance().Fire(ConfigContext.FlowerEvent, "kill");
    }

    public override void Reset()
    {
        base.Reset();
        if(_anim != null)
            _anim.SetBool("enable", false);

        _isEnable = false;
    }
}
