using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Common
{ 
public class Singleton<T> : MonoBehaviour where T : Component
{
    static T _instance;

    protected virtual void Awake()
    {
        if ((Singleton<T>._instance != null) && (Singleton<T>._instance.gameObject != base.gameObject))
        {
            if (Application.isPlaying)
            {
                UnityEngine.Object.Destroy(base.gameObject);
            }
            else
            {
                UnityEngine.Object.DestroyImmediate(base.gameObject);
            }
        }
        else if (Singleton<T>._instance == null)
        {
            Singleton<T>._instance = base.GetComponent<T>();
        }
        //UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
        this.Init();
    }

    public static T GetInstance()
    {
        if ((Singleton<T>._instance == null))
        {
            Type type = typeof(T);
            Singleton<T>._instance = (T)UnityEngine.Object.FindObjectOfType(type);
            if (Singleton<T>._instance == null)
            {
                GameObject obj2 = new GameObject(typeof(T).Name);
                Singleton<T>._instance = obj2.AddComponent<T>();
            }
        }
        return Singleton<T>._instance;
    }

    public static bool HasInstance()
    {
        return (Singleton<T>._instance != null);
    }

    protected virtual void Init()
    {
    }

}
}
