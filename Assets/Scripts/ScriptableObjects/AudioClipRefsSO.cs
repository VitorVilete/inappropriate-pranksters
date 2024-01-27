using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipRefs", menuName = "Game/Audio Clip Refs")]
public class AudioClipRefsSO : ScriptableObject
{
    public AudioClip[] clap;
    public AudioClip[] laughter;
    public AudioClip levelWin;
    public AudioClip levelLoss;
}
