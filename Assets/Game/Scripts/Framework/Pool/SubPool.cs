using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//子对象池类
public class SubPool
{
    //预设
    GameObject m_prefab;

    //集合列表（用于装所有生成的预设体）
    List<GameObject> m_objects = new List<GameObject>();

    //名字标识(根据所装预制体的名字定义,只读属性)
    public string Name
    {
        get { return m_prefab.name; }
    }

    //构造(构造时确定预制体)
    public SubPool(GameObject prefab)
    {
        this.m_prefab = prefab;
    }

    //取对象
    public GameObject Spawn()
    {
        GameObject go = null;

        //看子对象池中是否有多余的对象提取
        foreach (GameObject obj in m_objects)
        {
            if (!obj.activeInHierarchy)
            {
                go = obj;
                break;
            }
        }

        if (go == null) //表示该子对象池中没有多余的对象提取,立即重新生成一个新的预制体
        {
            go = GameObject.Instantiate(m_prefab);
            m_objects.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);
        return go;
    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        if (Contains(go))
        {
            go.SendMessage("OnUnspawn",SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    //回收所有对象
    public void UnspawnAll()
    {
        foreach (GameObject obj in m_objects)
        {
            if (obj.activeInHierarchy)
            {
                Unspawn(obj);
            }
        }
    }

    //是否包含对象
    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }

}
