using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterviewMinigame : MonoBehaviour
{
    [SerializeField] private Image tvChannelVisual;
    [SerializeField] private List<TVChannelSO> TVChannelSOList;
    [SerializeField] private TVChannelSO noiseTVChannelSO;
    [SerializeField] private Slider laughterMeterSlider;
    [SerializeField] private GameInput gameInput;
    private TVChannelSO currentTVChannelSO;
    private float laughterMeter;
    private float laughterMeterMin = 0f;
    private float laughterDamageMin = 3f;
    private float laughterDamageMax = 10f;
    private float laughterRecover = 1f;
    private float laughterMeterMax = 100f;
    private float tvChannelTimerMax = 5f;
    private float tvChannelTimerMin = 2f;
    private float tvChannelTimer;
    private bool isCurrentTVChannelNoise;

    private void Start()
    {
        ChangeCurrentChannelToNoise();
        laughterMeter = laughterMeterMin;
        laughterMeterSlider.minValue = laughterMeterMin;
        laughterMeterSlider.maxValue = laughterMeterMax;
    }

    private void FixedUpdate()
    {
        if (MinigameManager.Instance.IsGamePlaying())
        {
            HandleLaughter();
            HandleTVChannel();
        }
    }

    private void HandleLaughter()
    {
        if (gameInput.isInteracting())
        {
            if (currentTVChannelSO.isFunny) 
            {
                laughterMeter += laughterDamageMin * Time.deltaTime;
                laughterMeterSlider.value = laughterMeter;
            }
            else
            {
                laughterMeter += laughterDamageMax * Time.deltaTime;
                laughterMeterSlider.value = laughterMeter;
            }

        }
        else
        {
            if (currentTVChannelSO.isFunny)
            {
                laughterMeter += laughterDamageMax * Time.deltaTime;
                laughterMeterSlider.value = laughterMeter;
            }
            else
            {
                laughterMeter -= laughterRecover * Time.deltaTime;
                laughterMeterSlider.value = laughterMeter;
            }
        }
        if (laughterMeter >= laughterMeterMax)
        {
            MinigameManager.Instance.triggerLose();
            MinigameManager.Instance.triggerGameOver();
        }
    }

    private void HandleTVChannel()
    {
        tvChannelTimer -= Time.deltaTime;
        if (tvChannelTimer <= 0)
        {
            ResetTvChannelTimer();
            if (isCurrentTVChannelNoise)
            {
                ChangeCurrentChannelToRandomChannel();
            }
            else
            {
                ChangeCurrentChannelToNoise();
            }
        }
    }

    private void ChangeCurrentChannelToNoise()
    {
        isCurrentTVChannelNoise = true;
        currentTVChannelSO = noiseTVChannelSO;
        ChangeChannelVisualToCurrentTVChannel();
    }

    private void ChangeCurrentChannelToRandomChannel()
    {
        isCurrentTVChannelNoise = false;
        currentTVChannelSO = TVChannelSOList[Random.Range(0, TVChannelSOList.Count)];
        ChangeChannelVisualToCurrentTVChannel();
    }

    private void ChangeChannelVisualToCurrentTVChannel()
    {
        tvChannelVisual.sprite = currentTVChannelSO.channelSprite;
    }

    private void ResetTvChannelTimer()
    {
        tvChannelTimer = Random.Range(tvChannelTimerMin, tvChannelTimerMax);
    }
}
