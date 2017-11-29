using System;
using UnityEngine.UI;

public class UIWin : View
{
    #region 字段

    public Text txtCurrent;
    public Text txtTotal;
    public Button btnRestart;
    public Button btnContinue;

    #endregion 字段

    #region 属性

    public override string Name
    {
        get { return Consts.V_Win; }
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

    public void UpdateRoundInfo(int currentRound, int totalRound)
    {
        txtCurrent.text = currentRound.ToString("D2");
        txtTotal.text = totalRound.ToString();
    }

    #endregion 方法

    #region Unity回调

    private void Awake()
    {
        UpdateRoundInfo(0, 0);
    }

    #endregion Unity回调

    #region 事件回调

    public override void HandleEvent(string eventName, object data)
    {
    }

    public void OnRestartClick()
    {
    }

    public void OnContinueClick()
    {
    }

    #endregion 事件回调
}