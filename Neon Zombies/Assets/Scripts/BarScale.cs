using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScale : MonoBehaviour
{
    public GameObject bar;
    public GameObject barback;
    public float x;
    public float y;
    public Image HappyUI;
    public Image FearUI;
    public Image SadUI;
    public bool isSelected;

    public PlayerStateController StateController;
    public void BarScaler() {
        float width = bar.GetComponent<RectTransform>().sizeDelta.x;
        float height = bar.GetComponent<RectTransform>().sizeDelta.y;
        x *= width;
        y *= height;
        bar.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
        barback.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);

    }
    public void Update()
    {
        if (StateController.PlayerState == Emotions.Fear)
        {
            HappyUI.fillAmount += 0.1f * Time.deltaTime;
            FearUI.fillAmount -= 0.05f * Time.deltaTime;
            SadUI.fillAmount += 0.1f * Time.deltaTime;
        }
        else if (StateController.PlayerState == Emotions.Happiness)
        {
            HappyUI.fillAmount -= 0.05f * Time.deltaTime;
            FearUI.fillAmount += 0.1f * Time.deltaTime;
            SadUI.fillAmount += 0.1f * Time.deltaTime;
        }
        else if(StateController.PlayerState == Emotions.Sadness)
        {
            HappyUI.fillAmount += 0.1f * Time.deltaTime;
            FearUI.fillAmount += 0.1f * Time.deltaTime;
            SadUI.fillAmount -= 0.05f * Time.deltaTime;
        }
    }
}

