using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

//抽象类，不能实例化，但能声明（只能被继承）
public abstract class ReusableObject : MonoBehaviour, IReusable
{
    public abstract void OnSpawn();

    public abstract void OnUnspawn();
}
