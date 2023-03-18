using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FowParameters : MonoBehaviour
{
    [SerializeField] float transitionTime = 0.1f;
    GameObject fow;
    Vector3 initialScale;

    private void Awake()
    {
        fow = gameObject;
        initialScale = fow.transform.localScale;
    }

    public void ResetScale() => StartCoroutine(ChangeScale(initialScale)); //fow.transform.localScale = initialScale;
    public void IncreaseScale(float scaleMultiplier) => StartCoroutine(ChangeScale(scaleMultiplier* initialScale)); //fow.transform.localScale *= scaleMultiplier;

    IEnumerator ChangeScale(Vector3 target)
    {
        float step = 0.005f;
        int iterations = (int)(transitionTime / step);
        Vector3 diff = (target - fow.transform.localScale) / iterations;
        for (int i = 0; i < iterations; i++)
        {
            fow.transform.localScale += diff;
            yield return new WaitForSeconds(step);
        }
    }
}
