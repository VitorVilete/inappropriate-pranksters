using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterviewPlayerVisual : MonoBehaviour
{
    private bool isPlaying = false;
    private const string IS_PLAYING = "IS_PLAYING";
    [SerializeField] Animator interviewPlayerAnimator;

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
        interviewPlayerAnimator.SetBool(IS_PLAYING, isPlaying);
    }
}
