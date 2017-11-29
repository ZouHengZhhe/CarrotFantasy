using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.UI;

public class UISystem : View
{
    #region 字段

    public Button btnResume;
    public Button btnRestart;
    public Button btnSelect;

    #endregion 字段

    #region 属性

    public override string Name
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    #endregion 属性

    #region 方法

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    #endregion 方法

    #region 事件回调

    public override void HandleEvent(string eventName, object data)
    {
        throw new NotImplementedException();
    }

    public void OnResumeClick()
    {
    }

    public void OnRestartClick()
    {
    }

    public void OnSelectClick()
    {
    }

    #endregion 事件回调
}