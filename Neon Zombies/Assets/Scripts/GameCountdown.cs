using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameCountdown : MonoBehaviour
{
    [SerializeField] float overallTimeSeconds = 180f;
    [SerializeField] Image fill;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject endPanel;
    [SerializeField] MusicControl music;

    [HideInInspector] public float currentTimer = 0f;

    private void Start()
    {
        currentTimer = overallTimeSeconds;

    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;
        text.text = (Mathf.FloorToInt(currentTimer / 60)).ToString("00") + ":" + (Mathf.FloorToInt(currentTimer % 60)).ToString("00");
        fill.fillAmount = currentTimer / overallTimeSeconds;

        if (currentTimer <= 0)
        {
            Debug.Log("Time has ended");
            endPanel.SetActive(true);
            music.PlayLose();
        }
    }
}
