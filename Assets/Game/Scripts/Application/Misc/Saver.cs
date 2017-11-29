using UnityEngine;

internal static class Saver
{
    public static int GetProgress()
    {
        return PlayerPrefs.GetInt(Consts.GameProgress, -1);
    }

    public static void SetProgress(int levelIndex)
    {
        PlayerPrefs.SetInt(Consts.GameProgress, levelIndex);
    }
}