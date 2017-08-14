using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//总对象池类
public class ObjectPool:Singleton<ObjectPool>
{
    public string ResourceDir = "";

    Dictionary<string, SubPool> m_Pools = new Dictionary<string, SubPool>();

    //取对象
    public GameObject Spawn(string name)
    {
        if (!m_Pools.ContainsKey(name))
            RegisterNew(name);
        SubPool pool = m_Pools[name];
        return pool.Spawn();
    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;
        foreach (SubPool p in m_Pools.Values)
        {
            if (p.Contains(go))
            {
                pool = p;
                break;
            }
        }
        pool.Unspawn(go);
    }

    //回收所有对象
    public void UnspawnAll()
    {
        foreach (SubPool p in m_Pools.Values)
        {
            p.UnspawnAll();
        }
    }

    //创建新子池子
    void RegisterNew(string name)
    {
        //预设路径
        string path = "";
        if (string.IsNullOrEmpty(ResourceDir))
        {
            path = name;
        }
        else
        {
            path = ResourceDir + "/" + name;
        }

        //加载预设
        GameObject prefab=Resources.Load<GameObject>(path);

        //创建子对象池   
        SubPool pool=new SubPool(prefab);
        m_Pools.Add(pool.Name,pool);
    }
}
