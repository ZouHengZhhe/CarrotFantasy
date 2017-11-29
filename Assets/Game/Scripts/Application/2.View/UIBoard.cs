using System;
using UnityEngine.UI;

public class UIBoard : View
{
    #region 字段

    public Text txtScore;
    public Image imgRoundInfo;
    public Text txtCurrent;
    public Text txtTotal;
    public Image imgPauseInfo;
    public Button btnSpeed1;
    public Button btnSpeed2;
    public Button btnResume;
    public Button btnPause;
    public Button btnSystem;

    private bool m_IsPlaying = false;
    private GameSpeed m_Speed = GameSpeed.One;
    private int m_Gold = 0;

    #endregion 字段

    #region 属性

    public override string Name
    {
        get { return Consts.V_Board; }
    }

    public bool IsPlaying
    {
        get { return m_IsPlaying; }
        set
        {
            m_IsPlaying = value;

            imgRoundInfo.gameObject.SetActive(value);
            imgPauseInfo.gameObject.SetActive(!value);
        }
    }

    public GameSpeed Speed
    {
        get { return m_Speed; }
        set
        {
            m_Speed = value;

            btnSpeed1.gameObject.SetActive(m_Speed == GameSpeed.One);
            btnSpeed2.gameObject.SetActive(m_Speed == GameSpeed.Two);
        }
    }

    public int Score
    {
        get { return m_Gold; }
        set
        {
            m_Gold = value;
            txtScore.text = value.ToString();
        }
    }

    #endregion 属性

    #region 方法

    public void UpdateRoundInfo(int currentRound, int totalRound)
    {
        txtCurrent.text = currentRound.ToString("D2"); //始终保留2位整数
        txtTotal.text = totalRound.ToString();
    }

    #endregion 方法

    #region Unity回调

    public UICountDown UICountDown;

    private void Awake()
    {
        this.Score = 0;
        this.IsPlaying = true;
        this.Speed = GameSpeed.One;

        //开始倒计时
        UICountDown.StartCountDown();
    }

    #endregion Unity回调

    #region 事件回调

    public override void RegisterEvents()
    {
        //注册关心的事件
        this.AttentionEvents.Add(Consts.E_CountDownComplete);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_CountDownComplete:
                //游戏通关
                Game.Instance.LoadScene(4);
                break;
        }
    }

    public void OnSpeed1Click()
    {
        Speed = GameSpeed.One;
    }

    public void OnSpeed2Click()
    {
        Speed = GameSpeed.Two;
    }

    public void OnPauseClick()
    {
        IsPlaying = false;
    }

    public void OnResumeClick()
    {
        IsPlaying = true;
    }

    public void OnSystemClick()
    {
    }

    #endregion 事件回调
}