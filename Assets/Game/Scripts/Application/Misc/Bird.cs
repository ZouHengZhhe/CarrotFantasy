using UnityEngine;

public class Bird : MonoBehaviour
{
    public float time = 1;     //一次循环所需时间
    public float OffsetY = 2;  //Y方向浮动偏移

    private void Start()
    {
        iTween.MoveBy(this.gameObject, iTween.Hash("y", OffsetY, "easeType", iTween.EaseType.easeInOutSine, "loopType", iTween.LoopType.pingPong, "time", time));
    }
}