using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 싱글턴 일반화 구성

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour   
{
    // 인스턴스 전역 선언
    private static T instance;
    public static T Instance { get { return instance; } }


    protected virtual void Awake()
    {
        // 하나의 객체만 존재
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 싱글턴 인스턴스 생성
    public static void CreateInstance()
    {
        // 싱글턴 프리팹 파일 경로 Resources/Singleton
        // Resources/Singleton/생성하고자하는 매니저 프리팹 
        T resource = Resources.Load<T>($"Singleton/{typeof(T).Name}");
        instance = Instantiate(resource);
    }

    // 싱글턴 인스턴스 할당 해제
    public static void ReleaseInstance()
    {
        if (instance == null)
            return;

        Destroy(instance.gameObject);
        instance = null;
    }
}
