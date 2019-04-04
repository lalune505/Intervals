using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanvasController : MonoBehaviour
{
    #region PUBLIC_MEMBERS
    public const string MenuScenePath = "Assets/Scenes/FirstScene.unity";
    public const string LoadingScenePath = "Assets/Scenes/LoadingScene.unity";
    public const string StickerScenePath = "Assets/Scenes/StickersScene.unity";
    public const string MappingScenePath = "";

   
    public static void LoadScene(string scenePath)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scenePath);
    }

    public static void SetSceneToLoad(string scenePath)
    {
        LoadingScreen.SceneToLoad = scenePath;
    }

    #endregion //PUBLIC_MEMBERS

}
