using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarScale : MonoBehaviour
{
    public GameObject bar;
    public GameObject barback;
    public float x;
    public float y;
    public void BarScaler() {
        float width = bar.GetComponent<RectTransform>().sizeDelta.x;
        float height = bar.GetComponent<RectTransform>().sizeDelta.y;
        x *= width;
        y *= height;
        bar.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);
        barback.GetComponent<RectTransform>().sizeDelta = new Vector2(x, y);

    }   

}
