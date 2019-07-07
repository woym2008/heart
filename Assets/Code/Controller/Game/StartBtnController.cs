using UnityEngine;
using System.Collections;

public class StartBtnController : LogicController
{
    SpriteRenderer _renderer;

    public Sprite _trangle;
    public Sprite _quad;

    private void Start()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }
    public override void ActiveUpdate(float dt)
    {
        base.ActiveUpdate(dt);
    }

    public void OnStart(string parm)
    {
        Debug.Log("Start");
    }

    public override void OnActiveInput()
    {
        base.OnActiveInput();
    }
    public override void OnStopInput()
    {
        base.OnStopInput();

        ProcessManager.GetInstance().SetState(new RunProcess());

        _renderer.sprite = _quad;
    }

    public override void Reset()
    {
        //base.Reset();
        if(_renderer != null)
            _renderer.sprite = _trangle;
    }
}
