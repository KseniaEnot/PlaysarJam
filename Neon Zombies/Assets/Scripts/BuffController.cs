using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    [SerializeField] float overloadTime;
    [Header("Fear Buff")]
    [SerializeField] float increasedSpeed;
    [SerializeField] float increasedRotationSpeed;

    private PlayerStateController stateController;
    private PlayerMove playerMove;
    private Emotions currentEmotion = Emotions.Happiness;

    private void Awake()
    {
        stateController = GetComponent<PlayerStateController>();
        playerMove = GetComponent<PlayerMove>();
        stateController.StateChanged += OnStateChange;
    }


    void OnStateChange(Emotions newEmotion)
    {
        ResetEmotionBuff(currentEmotion);
        SetEmotionBuff(newEmotion);
        currentEmotion = newEmotion;
    }

    void OverloadEmotion()
    {
        SetEmotionDebuff(currentEmotion);
        //forbid to change emotions
        StartCoroutine(WaitOverloadEnd());
    }

    IEnumerator WaitOverloadEnd()
    {
        float currentTime = 0f;
        while (currentTime < overloadTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        ResetEmotionDebuff(currentEmotion);
        SetEmotionDebuff(currentEmotion);
    }

    void SetEmotionBuff(Emotions emo)
    {
        switch (emo)
        {
            case Emotions.Happiness:
                //increase fog of war
                break;
            case Emotions.Fear:
                playerMove.Speed = increasedSpeed;
                playerMove.Rotation = increasedRotationSpeed;
                break;
            case Emotions.Sadness:
                //set some flaf to avoid traps to true
                break;
        }
    }
    void SetEmotionDebuff(Emotions emo)
    {
        switch (emo)
        {
            case Emotions.Happiness:
                //light up the screen
                break;
            case Emotions.Fear:
                var newInput = GetComponent<RandomizeInput>();
                newInput.Initialize();
                playerMove.SetInputType(newInput);
                break;
            case Emotions.Sadness:
                playerMove.Speed = 0;
                break;
        }
    }
    void ResetEmotionBuff(Emotions emo) 
    {

        switch (currentEmotion)
        {
            case Emotions.Happiness:
                //bring fog of war to default
                break;
            case Emotions.Fear:
                playerMove.ResetSpeed();
                break;
            case Emotions.Sadness:
                //set some flaf to avoid traps to false
                break;
        }
    }
    void ResetEmotionDebuff(Emotions emo)
    {
        switch (currentEmotion)
        {
            case Emotions.Happiness:
                //bring fog of war to default
                break;
            case Emotions.Fear:
                playerMove.SetInputType(GetComponent<KeyboardInput>());
                break;
            case Emotions.Sadness:
                playerMove.ResetSpeed();
                break;
        }

    }
}
