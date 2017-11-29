using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class UIComplete : View
{
    #region 字段

    public Button btnSelect;
    public Button btnClear;

    #endregion 字段

    #region 属性

    public override string Name
    {
        get
        {
            return Consts.V_Complete;
        }
    }

    #endregion 属性

    #region 事件回调

    public override void RegisterEvents()
    {
    }

    public override void HandleEvent(string eventName, object data)
    {
    }

    public void OnSelectClick()
    {
        //回到开始界面
        Game.Instance.LoadScene(1);
    }

    public void OnClearClick()
    {
    }

    #endregion 事件回调
}