using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public interface IGameProcess
{
    void enter();
    void excute();
    void exit();
}

public class ProcessManager : Singleton<ProcessManager>
{
    public IGameProcess _state;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_state != null)
        {
            _state.excute();
        }
    }

    public  void SetState(IGameProcess state)
    {
        if(_state != null)
        {
            _state.exit();
        }
        _state = state;

        _state.enter();
    }
}
