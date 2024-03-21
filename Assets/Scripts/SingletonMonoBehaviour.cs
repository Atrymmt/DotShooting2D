using UnityEngine;
using System;

public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<T>();
                if (_instance == null)
                {
                    // GameObject obj = new GameObject(typeof(T).Name);
                    // _instance = obj.AddComponent<T>();
                    Debug.LogError($"No GameObject attached the type: {typeof(T).Name}");
                }
            }
            return _instance;
        }
    }

    virtual protected void Awake()
    {
        // 他のゲームオブジェクトにアタッチされているか調べる
        // アタッチされている場合は破棄する。
        if (_instance == null)
        {
            _instance = this as T;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
}