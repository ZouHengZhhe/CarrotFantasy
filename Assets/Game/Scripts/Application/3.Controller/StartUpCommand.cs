using UnityEngine.SceneManagement;

public class StartUpCommand : Controller
{
    public override void Execute(object data)
    {
        //注册模型（Model）

        //注册命令（控制器）（Controller）
        RegisterController(Consts.E_EnterScene, typeof(EnterSceneCommand));
        RegisterController(Consts.E_ExitScene, typeof(ExitSceneCommand));

        //进入开始界面
        Game.Instance.LoadScene(1);
    }
}