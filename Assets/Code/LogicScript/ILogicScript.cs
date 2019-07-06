using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogicScript
{
    void EnterActive();

    void ActiveUpdate(float dt);

    void EnterStop();

    void StopUpdate(float dt);

    void Reset();
}
