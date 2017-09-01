using System;
using System.Collections.Generic;
using UnityEngine;

//视图层（抽象类）
public abstract class View:MonoBehaviour
{
    public abstract string Name { get; }

    public List<string> AttationEvents=new List<string>();

    public abstract void HandleEvent(string eventName, object data = null);
}
