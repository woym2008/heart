using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        ProcessManager.GetInstance().SetState(new ReadyProcess());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
