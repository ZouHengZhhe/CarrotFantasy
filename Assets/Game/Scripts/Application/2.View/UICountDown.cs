using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UICountDown : View
{
    #region 字段

    public Image Count;
    public Sprite[] Numbers;

    #endregion 字段

    #region 属性

    public override string Name
    {
        get { return Consts.V_CountDown; }
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

    public void StartCountDown()
    {
        Show();
        StartCoroutine("DisplayCount");
    }

    private IEnumerator DisplayCount()
    {
        int count = 3;
        while (count > 0)
        {
            //显示
            Count.sprite = Numbers[count - 1];

            //自减
            count--;

            //等待一秒
            yield return new WaitForSeconds(1);

            if (count <= 0)
            {
                break;
            }
        }
        Hide();

        //倒计时结束
        SendEvent(Consts.E_CountDownComplete);
    }

    #endregion 方法

    #region 事件回调

    public override void RegisterEvents()
    {
        this.AttentionEvents.Add(Consts.E_EnterScene);
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_EnterScene:
                SceneArgs e = (SceneArgs)data;
                if (e.SceneIndex == 3)
                {
                    StartCountDown();
                }
                break;
        }
    }

    #endregion 事件回调
}