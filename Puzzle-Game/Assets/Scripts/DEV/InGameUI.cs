using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTMP;
    [SerializeField] TextMeshProUGUI goldTMP;
    [SerializeField] Slider teleportUsageSlider;
    [SerializeField] Slider teleportDurationSlider;

    [SerializeField] TeleportSO teleportSO;
    [SerializeField] Float timer;
    [SerializeField] Int playerGold;

    void Awake()
    {
        teleportSO.teleportTime.OnValueChanged += OnTeleportTimeChanged;
        teleportSO.skillDuration.OnValueChanged += OnTeleportUseDurationChanged;
        timer.OnValueChanged += OnTimerChanged;

        playerGold.OnValueChanged += OnPlayerGoldValueChanged;

        OnTeleportTimeChanged(teleportSO.teleportTime.Value);
        OnTeleportUseDurationChanged(teleportSO.skillDuration.Value);
    }

    void OnDisable()
    {
        teleportSO.teleportTime.OnValueChanged -= OnTeleportTimeChanged;
        teleportSO.skillDuration.OnValueChanged -= OnTeleportUseDurationChanged;
        timer.OnValueChanged -= OnTimerChanged;
        playerGold.OnValueChanged -= OnPlayerGoldValueChanged;
    }

    private void OnTeleportTimeChanged(float newValue)
    {
        teleportUsageSlider.value = newValue / teleportSO.teleportMaxTime.Value;
        if (newValue <= 0f)
        {
            teleportUsageSlider.gameObject.SetActive(false);
        }
        else if (!teleportUsageSlider.gameObject.activeSelf)
        {
            teleportUsageSlider.gameObject.SetActive(true);
        }
    }

    private void OnTimerChanged(float newValue)
    {
        timerTMP.SetText(newValue.ToString("F1"));
    }

    private void OnTeleportUseDurationChanged(float newValue)
    {
        teleportDurationSlider.value = newValue / teleportSO.skillMaxDuration.Value;
    }

    private void OnPlayerGoldValueChanged(int value)
    {
        goldTMP.SetText(value.ToString());
    }
}

