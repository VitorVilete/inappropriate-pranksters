using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TVChannel", menuName = "Game/TVChannel")]
public class TVChannelSO : ScriptableObject
{
    public bool isFunny;
    public string channelName;
    public Sprite channelSprite;
}
