using UnityEngine;
using System.Collections;

public class OverProcess : IGameProcess
{
    public void enter()
    {
        //throw new System.NotImplementedException();
        EventManager.GetInstance().Fire(ConfigContext.KeyEvent,"enterover");

        EventManager.GetInstance().Fire(ConfigContext.HeartEvent, "enterover");

    }

    public void excute()
    {
        //throw new System.NotImplementedException();
    }

    public void exit()
    {
        //throw new System.NotImplementedException();
    }
}
