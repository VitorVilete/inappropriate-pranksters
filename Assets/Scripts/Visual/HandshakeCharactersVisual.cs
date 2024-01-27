using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandshakeCharactersVisual : MonoBehaviour
{
    private bool isPlaying = false;
    private const string IS_PLAYING = "IS_PLAYING";
    [SerializeField] Animator handshakeCharactersAnimator;

    void Start()
    {
        MinigameManager.Instance.OnStateChanged += MinigameManager_OnStateChanged;        
    }

    private void MinigameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (MinigameManager.Instance.IsGamePlaying())
        {
            isPlaying = true;
        }
        else
        {
            isPlaying = false;
        }
        handshakeCharactersAnimator.SetBool(IS_PLAYING, isPlaying);
    }
}
