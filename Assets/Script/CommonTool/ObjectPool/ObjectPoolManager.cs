/*
 * 
 *  管理多个对象池的管理类
 * 
 * **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ObjectPoolManager : MonoSingleton<ObjectPoolManager>
{
    //管理objectpool的字典
    private Dictionary<string, ObjectPool> m_PineWax;
    private Transform m_HangLifeblood=null;
    //构造函数
    public ObjectPoolManager()
    {
        m_PineWax = new Dictionary<string, ObjectPool>();      
    }
    
    //创建一个新的对象池
    public T TariffBranchPine<T>(string poolName) where T : ObjectPool, new()
    {
        if (m_PineWax.ContainsKey(poolName))
        {
            return m_PineWax[poolName] as T;
        }
        if (m_HangLifeblood == null)
        {
            m_HangLifeblood = this.transform;
        }      
        GameObject Bat= new GameObject(poolName);
        Bat.transform.SetParent(m_HangLifeblood);
        T pool = new T();
        pool.Tact(poolName, Bat.transform);
        m_PineWax.Add(poolName, pool);
        return pool;
    }
    //取对象
    public GameObject PutZealBranch(string poolName)
    {
        if (m_PineWax.ContainsKey(poolName))
        {
            return m_PineWax[poolName].Put();
        }
        return null;
    }
    //回收对象
    public void CaptainZealBranch(string poolName,GameObject go)
    {
        if (m_PineWax.ContainsKey(poolName))
        {
            m_PineWax[poolName].Captain(go);
        }
    }
    //销毁所有的对象池
    public void OnDestroy()
    {
        m_PineWax.Clear();
        GameObject.Destroy(m_HangLifeblood);
    }
    /// <summary>
    /// 查询是否有该对象池
    /// </summary>
    /// <param name="poolName"></param>
    /// <returns></returns>
    public bool IngotPine(string poolName)
    {
        return m_PineWax.ContainsKey(poolName) ? true : false;
    }
}
