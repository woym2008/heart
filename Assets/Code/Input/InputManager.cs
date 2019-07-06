using UnityEngine;
using System.Collections;
using Common;

public class InputManager : Singleton<InputManager>,ILogicScript
{
    public Camera camera;

    private void Start()
    {
        LogicScriptManager.GetInstance().AddLogicScript(this);
    }


    public void ActiveUpdate(float dt)
    {
        //点了左键了
        if(Input.GetMouseButtonDown(0))
        {
            //计算位置
            var point = camera.ScreenToWorldPoint(Input.mousePosition);
            //打射线
            var c = Physics2D.OverlapPoint(point);

            if(c != null)
            {
                var controller = c.gameObject.GetComponent<LogicController>();
                if(controller != null)
                {
                    controller.OnActiveInput();
                }
            }
        }
    }

    public void StopUpdate(float dt)
    {
        //点了左键了
        if (Input.GetMouseButtonDown(0))
        {
            //计算位置
            var point = camera.ScreenToWorldPoint(Input.mousePosition);
            //打射线
            var c = Physics2D.OverlapPoint(point);

            if (c != null)
            {
                var controller = c.gameObject.GetComponent<LogicController>();
                if (controller != null)
                {
                    controller.OnStopInput();
                }
            }
        }
    }

    public void EnterActive()
    {
        //throw new System.NotImplementedException();
    }

    public void EnterStop()
    {
        //throw new System.NotImplementedException();
    }

    public void Reset()
    {
        //throw new System.NotImplementedException();
    }
}
