using System;

public class UISelect : View
{
    #region 属性

    public override string Name
    {
        get { return Consts.V_Select; }
    }

    #endregion 属性

    #region 方法

    //返回开始界面
    public void GoBack()
    {
        Game.Instance.LoadScene(1);
    }

    //选择关卡游戏
    public void ChooseLevel()
    {
        StartLevelArgs e = new StartLevelArgs()
        {
            LevelIndex = 0
        };

        SendEvent(Consts.E_StartLevel, e);
    }

    #endregion 方法

    #region 事件回调

    public override void HandleEvent(string eventName, object data)
    {
        throw new NotImplementedException();
    }

    #endregion 事件回调
}