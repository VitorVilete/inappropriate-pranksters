using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button resumeLevelButton;
    [SerializeField] private Button retryLevelButton;
    [SerializeField] private Button mainMenuLevelButton;

    private void Awake()
    {
        resumeLevelButton.onClick.AddListener(() =>
        {
            MinigameManager.Instance.TogglePauseGame();
        });
        retryLevelButton.onClick.AddListener(() =>
        {
            Loader.ReloadScene();
            Time.timeScale = 1f;
        });
        mainMenuLevelButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    void Start()
    {
        MinigameManager.Instance.OnGamePaused += MinigameManager_OnGamePaused;
        MinigameManager.Instance.OnGameUnpaused += MinigameManager_OnGameUnpaused;
        Hide();
    }

    private void MinigameManager_OnGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void MinigameManager_OnGamePaused(object sender, System.EventArgs e)
    {
        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
