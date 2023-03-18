using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
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
        stateController.EmotionOverloaded += OverloadEmotion;
        stateController.EmotionOverloadEnded += OverloadEmotionEnded;
    }


    void OnStateChange(Emotions newEmotion)
    {
        ResetEmotionBuff();
        SetEmotionBuff(newEmotion);
        currentEmotion = newEmotion;
    }

    void OverloadEmotion()
    {
        SetEmotionDebuff(currentEmotion);
        //forbid to change emotions
    }
    void OverloadEmotionEnded()
    {
        ResetEmotionDebuff();
        SetEmotionBuff(currentEmotion);
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
    void ResetEmotionBuff() 
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
    void ResetEmotionDebuff()
    {
        switch (currentEmotion)
        {
            case Emotions.Happiness:
                //bring fog of war to default
                break;
            case Emotions.Fear:
                playerMove.SetInputType(KeyboardInput.getInstance());
                break;
            case Emotions.Sadness:
                playerMove.ResetSpeed();
                break;
        }

    }
}
