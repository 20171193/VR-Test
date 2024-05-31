using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̱��� �Ϲ�ȭ ����

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour   
{
    // �ν��Ͻ� ���� ����
    private static T instance;
    public static T Instance { get { return instance; } }


    protected virtual void Awake()
    {
        // �ϳ��� ��ü�� ����
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

    // �̱��� �ν��Ͻ� ����
    public static void CreateInstance()
    {
        // �̱��� ������ ���� ��� Resources/Singleton
        // Resources/Singleton/�����ϰ����ϴ� �Ŵ��� ������ 
        T resource = Resources.Load<T>($"Singleton/{typeof(T).Name}");
        instance = Instantiate(resource);
    }

    // �̱��� �ν��Ͻ� �Ҵ� ����
    public static void ReleaseInstance()
    {
        if (instance == null)
            return;

        Destroy(instance.gameObject);
        instance = null;
    }
}
