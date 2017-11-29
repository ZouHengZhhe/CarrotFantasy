using UnityEngine.SceneManagement;

public class StartUpCommand : Controller
{
    public override void Execute(object data)
    {
        //注册模型（Model）
        RegisterModel(new GameModel());

        //注册命令（控制器）（Controller）
        RegisterController(Consts.E_EnterScene, typeof(EnterSceneCommand));
        RegisterController(Consts.E_ExitScene, typeof(ExitSceneCommand));
        RegisterController(Consts.E_StartLevel, typeof(StartLevelCommand));
        RegisterController(Consts.E_EndLevel, typeof(EndLevelCommand));

        //初始化
        GameModel gModel = GetModel<GameModel>();
        gModel.Initialize();

        //进入开始界面
        Game.Instance.LoadScene(1);
    }
}