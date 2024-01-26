using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        GameHandshakeScene,
        GameIntermissionScene,
        GameInterviewScene,
        GameStealthChaseScene,
        LoadingScene,
        MainMenuScene,
        CreditsScene
    }

    public static Scene targetScene;
    public static Scene previousScene;

    public static void Load(Scene targetScene)
    {
        Enum.TryParse(SceneManager.GetActiveScene().name, out previousScene);
        Debug.Log(previousScene.ToString());
        Loader.targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
