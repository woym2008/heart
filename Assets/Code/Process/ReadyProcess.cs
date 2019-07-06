using UnityEngine;
using System.Collections;

public class ReadyProcess : IGameProcess
{
    public void enter()
    {
        LogicScriptManager.GetInstance().EnterStop();

        LogicScriptManager.GetInstance().Reset();
    }

    public void excute()
    {
        LogicScriptManager.GetInstance().StopUpdate(Time.deltaTime);
    }

    public void exit()
    {
        //throw new System.NotImplementedException();
    }
}
