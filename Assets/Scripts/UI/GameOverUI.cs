using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Button retryLevelButton;

    private void Awake()
    {
        retryLevelButton.onClick.AddListener(() =>
        {
            Loader.ReloadScene();
        });
    }

    void Start()
    {
        MinigameManager.Instance.OnStateChanged += MinigameManager_OnStateChanged;
        Hide();
    }

    private void MinigameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (MinigameManager.Instance.IsGameOver() && !MinigameManager.Instance.IsWin())
        {
            Show();
        }
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
