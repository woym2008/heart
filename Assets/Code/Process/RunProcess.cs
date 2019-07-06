using UnityEngine;
using System.Collections;

public class RunProcess : IGameProcess
{
    public void enter()
    {
        LogicScriptManager.GetInstance().EnterActive();
    }

    public void excute()
    {
        LogicScriptManager.GetInstance().ActiveUpdate(Time.deltaTime);
    }

    public void exit()
    {
    }
}
