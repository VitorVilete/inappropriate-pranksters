using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameIntermissionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI intermissionText;
    [SerializeField] private Button nextButton;
    [SerializeField] private List<GameIntermissionSO> gameIntermissionSOList;
    private GameIntermissionSO currentGameIntermissionSO;

    private void Awake()
    {
        currentGameIntermissionSO = gameIntermissionSOList.Find(a => a.previousScene == Loader.previousScene);
        Debug.Log(currentGameIntermissionSO);
        intermissionText.text = currentGameIntermissionSO.gameIntermissionText;

        nextButton.onClick.AddListener(() =>
        {
            Loader.Load(currentGameIntermissionSO.nextScene);
        });

    }

}
