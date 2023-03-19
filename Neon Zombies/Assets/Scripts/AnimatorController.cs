using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private PlayerStateController stateController;

    [SerializeField]
    private CharacterController controller;

    [SerializeField]
    private SoundContorol _soundController;

    private PlayerMove playerMove;

    void Start()
    {
        stateController.StateChanged += OnEmotionChange;
    }

    // Update is called once per frame
    void Update()
    {
        bool isMoving = controller.velocity.magnitude > 0f;
        playerAnimator.SetBool("isMoving", isMoving);
        if (isMoving) _soundController.PlayRun();
        else _soundController.StopRun();


    }

    private void OnEmotionChange(Emotions emotion)
    {
        switch (emotion)
        {
            case Emotions.Happiness:
                playerAnimator.SetTrigger("isHappy");
                break;
            case Emotions.Sadness:
                playerAnimator.SetTrigger("isSad");
                break;
            case Emotions.Fear:
                playerAnimator.SetTrigger("isAngry");
                break;
        }
    }
}
