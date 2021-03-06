using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    protected virtual void Awake()
    {
        Init();
    }

    public static T Instance { get { return instance; } private set { instance = value; } }

    private void Init()
    {
        if (Instance == null || Instance.Equals(null))
            Instance = this as T;
        else if (Instance != this as T)
            Destroy(gameObject);
    }
}
