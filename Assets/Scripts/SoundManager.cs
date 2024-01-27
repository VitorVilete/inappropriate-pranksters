using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MinigameManager.Instance.OnGameOver += MinigameManager_OnGameOver;
    }

    private void MinigameManager_OnGameOver(object sender, MinigameManager.OnGameOverEventArgs e)
    {
        if (e.isWin)
        {
            PlaySound(audioClipRefsSO.levelWin);
        }
        else
        {
            PlaySound(audioClipRefsSO.levelLoss);
        }
    }

    private void Update()
    {
        if (MinigameManager.Instance.IsGamePlaying())
        {
            //TODO: Implement Sounds at random intervals while playing
        }
    }

    private void PlaySound(AudioClip audioClip, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(audioClip, Vector3.zero, volume);
    }
}
