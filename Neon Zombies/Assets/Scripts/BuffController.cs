using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffController : MonoBehaviour
{
    [Header("Fear Buff")]
    [SerializeField] float increasedSpeed;
    [Header("Happiness Buff")]
    [SerializeField] float fowIncreaseScale;

    private PlayerStateController stateController;
    private PlayerMove playerMove;
    private FowParameters fow;
    private Emotions currentEmotion = Emotions.Happiness;

    private void Awake()
    {
        stateController = GetComponent<PlayerStateController>();
        playerMove = GetComponent<PlayerMove>();
        fow = GetComponentInChildren<FowParameters>();
        stateController.StateChanged += OnStateChange;
        stateController.EmotionOverloaded += OverloadEmotion;
        stateController.EmotionOverloadEnded += OverloadEmotionEnded;

        currentEmotion = Emotions.Happiness;
        SetEmotionBuff(Emotions.Happiness);
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
                fow.IncreaseScale(fowIncreaseScale);
                break;
            case Emotions.Fear:
                playerMove.Speed = increasedSpeed;
                break;
            case Emotions.Sadness:
                //flag is in script Trap for this
                break;
        }
    }
    void SetEmotionDebuff(Emotions emo)
    {
        switch (emo)
        {
            case Emotions.Happiness:
                //change to lighting it up
                fow.IncreaseScale(0);
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
                fow.ResetScale();
                break;
            case Emotions.Fear:
                playerMove.ResetSpeed();
                break;
            case Emotions.Sadness:
                //flag is in script Trap for this
                break;
        }
    }
    void ResetEmotionDebuff()
    {
        switch (currentEmotion)
        {
            case Emotions.Happiness:
                fow.ResetScale();
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
