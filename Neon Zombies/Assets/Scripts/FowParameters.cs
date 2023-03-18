using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowParameters : MonoBehaviour
{
    GameObject fow;
    Vector3 initialScale;

    private void Awake()
    {
        fow = gameObject;
        initialScale = fow.transform.localScale;
    }

    public void ResetScale() => fow.transform.localScale = initialScale;
    public void IncreaseScale(float scaleMultiplier) => fow.transform.localScale *= scaleMultiplier;

    IEnumerator ChangeScale()
    {
        float currentTime;
        float waitTime = 0.5f;
        float step = 0.005f;
        for (int i = 0; i < waitTime; i++)
        {

            yield return new WaitForSeconds(step);
        }
    }
}
