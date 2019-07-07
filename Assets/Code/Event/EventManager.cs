using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
using UnityEngine.Events;

public class LogicEvent : UnityEvent<string>
{

}
public class EventManager : Singleton<EventManager>
{
    Dictionary<string, LogicEvent> _events = new Dictionary<string, LogicEvent>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddListener(string name, UnityAction<string> func)
    {
        LogicEvent findevent = null;
        if(!_events.TryGetValue(name, out findevent))
        {
            findevent = new LogicEvent();
            _events[name] = findevent;
        }
        findevent.AddListener(func);
    }

    public void Fire(string name, string data)
    {
        LogicEvent findevent = null;
        if (_events.TryGetValue(name, out findevent))
        {
            _events[name].Invoke(data);
        }
    }
}
