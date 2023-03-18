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
    public PlayerStateController StateController;
    public float current = 0.05f;
    public float others = 0.1f;
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
            HappyUI.fillAmount -= others * Time.deltaTime;
            FearUI.fillAmount += current * Time.deltaTime;
            SadUI.fillAmount -= others * Time.deltaTime;
        }
        else if (StateController.PlayerState == Emotions.Happiness)
        {
            HappyUI.fillAmount += current * Time.deltaTime;
            FearUI.fillAmount -= others * Time.deltaTime;
            SadUI.fillAmount -= others * Time.deltaTime;
        }
        else if(StateController.PlayerState == Emotions.Sadness)
        {
            HappyUI.fillAmount -= others * Time.deltaTime;
            FearUI.fillAmount -= others * Time.deltaTime;
            SadUI.fillAmount += current * Time.deltaTime;
        }
    }
}

