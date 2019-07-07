using UnityEngine;
using System.Collections;

public class SignalController : LogicController
{
    bool _isUsed = false;

    bool _isEnable = false;

    private void Start()
    {
        EventManager.GetInstance().AddListener(ConfigContext.SignalEvent, OnSignal);

        _isUsed = false;
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnSignal(string param)
    {
        Debug.LogWarning("Signal");

        if(!_isEnable && param == "enable")
        {
            _isEnable = true;
        }
    }

    public override void Reset()
    {
        //base.Reset();
        _isUsed = false;
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();
        if(_isEnable)
        {
            Debug.LogWarning("Signal OnActiveInput");

            _isUsed = true;

            EventManager.GetInstance().Fire(ConfigContext.HerbicideEvent, "use");
        }

    }
}
