using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance { get; private set; }

    private void Init()
    {
        if (instance == null)
            instance = this as T;
        else if (instance != this)
            Destroy(gameObject);
    }

    private void Awake()
    {
        Init();
    }
}
