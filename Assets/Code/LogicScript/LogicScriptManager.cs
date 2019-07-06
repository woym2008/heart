using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Common;

public class LogicScriptManager : Singleton<LogicScriptManager>
{
    List<ILogicScript> _LogicObjects = new List<ILogicScript>();

    public void EnterActive()
    {
        foreach (var obj in _LogicObjects)
        {
            obj.EnterActive();
        }
    }
    public void ActiveUpdate(float dt)
    {
        foreach(var obj in _LogicObjects)
        {
            obj.ActiveUpdate(dt);
        }
    }

    public void EnterStop()
    {
        foreach (var obj in _LogicObjects)
        {
            obj.EnterStop();
        }
    }
    public void StopUpdate(float dt)
    {
        foreach (var obj in _LogicObjects)
        {
            obj.StopUpdate(dt);
        }
    }

    public void AddLogicScript(ILogicScript script)
    {
        _LogicObjects.Add(script);
    }

    public void Reset()
    {
        foreach (var obj in _LogicObjects)
        {
            obj.Reset();
        }
    }
}
