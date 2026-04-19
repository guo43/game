using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingle<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    DontDestroyOnLoad(obj);
                    instance = obj.AddComponent<T>();
                }
            }
            return instance;
        }
    }
    private static T instance;

    protected virtual void Awake()
    {
        instance = this as T;
    }
}
