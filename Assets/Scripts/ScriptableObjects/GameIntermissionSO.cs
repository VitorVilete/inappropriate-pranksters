using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="GameIntermission", menuName = "Game/GameIntermission")]
public class GameIntermissionSO : ScriptableObject
{
    public Loader.Scene previousScene;

    [Multiline(30)]
    public string gameIntermissionText;

    public Loader.Scene nextScene;
}
