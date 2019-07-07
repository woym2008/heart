using UnityEngine;
using System.Collections;

public class FlowerController : LogicController
{
    Animator _anim;
    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.FlowerEvent,OnFlower);

        _anim = this.gameObject.GetComponent<Animator>();
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);

        //test
        //if(Input.GetKeyDown(KeyCode.G))
        //{
        //    EventManager.GetInstance().Fire(ConfigContext.HeartEvent, "drop");
        //}
    }

    public void OnFlower(string param)
    {
        Debug.Log("FlowerController");

        if(param == "kill")
        {
            _anim.SetBool("iskilled", true);

            EventManager.GetInstance().Fire(ConfigContext.HeartEvent, "drop");
        }
    }

    public override void Reset()
    {
        base.Reset();
        if (_anim != null)
            _anim.SetBool("iskilled", false);
    }
}
