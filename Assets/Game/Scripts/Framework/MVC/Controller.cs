using System;
using System.Collections.Generic;

public abstract class Controller
{
    public abstract void HandleEvent(string eventName, object data = null);
}
