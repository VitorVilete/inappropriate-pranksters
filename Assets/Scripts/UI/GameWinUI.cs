using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinUI : MonoBehaviour
{
    [SerializeField] private Button nextLevelButton;

    private void Awake()
    {
        nextLevelButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameIntermissionScene);
        });
    }

    void Start()
    {
        MinigameManager.Instance.OnStateChanged += MinigameManager_OnStateChanged;
        Hide();
    }

    private void MinigameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (MinigameManager.Instance.IsGameOver() && MinigameManager.Instance.IsWin())
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
