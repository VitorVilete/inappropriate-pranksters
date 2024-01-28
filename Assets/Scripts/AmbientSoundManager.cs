using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    private void Awake()
    {
        audioSource.clip = audioClip;
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
