using System;
using System.Collections.Generic;
using UnityEngine;

//MVC框架启动入口
public abstract class ApplicationBase<T> : Singleton<T>
    where T : MonoBehaviour
{
    //注册控制器
    protected void RegisterController(string eventName, Type controllerType)
    {
        MVC.RegisterController(eventName, controllerType);
    }

    //执行
    protected void SendEvent(string eventName, object args = null)
    {
        MVC.SendEvent(eventName, null);
    }
}