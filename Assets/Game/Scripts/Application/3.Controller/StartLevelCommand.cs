internal class StartLevelCommand : Controller
{
    public override void Execute(object data)
    {
        //进入游戏
        Game.Instance.LoadScene(3);
    }
}