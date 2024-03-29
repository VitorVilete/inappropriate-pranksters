using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MinigameManager.Instance.OnGamePlaying += MinigameManager_OnGamePlaying;
        MinigameManager.Instance.OnGameOver += MinigameManager_OnGameOver;
    }

    private void MinigameManager_OnGameOver(object sender, MinigameManager.OnGameOverEventArgs e)
    {
        audioSource.Stop();
    }

    private void MinigameManager_OnGamePlaying(object sender, System.EventArgs e)
    {
        audioSource.Play();
    }
}
