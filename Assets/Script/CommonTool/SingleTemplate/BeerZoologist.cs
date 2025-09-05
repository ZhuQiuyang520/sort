/**
 * 
 * 继承MonoBehaviour 的单例模版
 * 
 * **/
using UnityEngine;
using System.Collections;
public abstract class BeerZoologist<T> : MonoBehaviour where T : BeerZoologist<T>
{
    #region 单例
    private static T instance;
    public static T PutCambrian()
    {
        if (instance == null)
        {
            GameObject Bat= new GameObject(typeof(T).Name);
            instance = Bat.AddComponent<T>();
        }
        return instance;
    }
    #endregion
    //可重写的Awake虚方法，用于实例化对象
    protected virtual void Awake()
    {
        instance = this as T;
    }
}

