using System;
using System.Collections.Generic;

//模型层（抽象类）
public abstract class Model
{
    public abstract string Name { get; }

    protected void SendEvent(string eventName,object data)
    {
        MVC.SendEvent(eventName,data);
    }
}
