using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeInput : MonoBehaviour, IInput
{
    [SerializeField] float randomTime = 1f;

    bool isWorking = false;
    bool isInverted = true;
    float countTime = 0f;

    Coroutine coroutine;

    public void Initialize()
    {
        isInverted = true;
        isWorking = true;
        countTime = 0f;
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = StartCoroutine(CountTime());
    }

    public void Stop() => StopCoroutine(coroutine);

    public Vector2 GetInput()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (isInverted)
            input = -input;

        return input;
    }

    private IEnumerator CountTime()
    {
        while (isWorking)
        {
            while (countTime < randomTime)
            {
                countTime += Time.deltaTime;
                yield return null;
            }
            countTime = 0f;
            isInverted = !isInverted;
        }
    }
}
