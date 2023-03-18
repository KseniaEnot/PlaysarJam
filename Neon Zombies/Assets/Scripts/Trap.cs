using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private float _timeIntTrap = 10f;

    [SerializeField]
    private float _progressSize = 10f;

    [SerializeField]
    private float _progressOneTapPower = 1f;

    private float _trapProgress = 0f;
    private float _trapTimer = 0f;
    private bool _isInTrap = false;


    private void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        PlayerStateController stateController;

        if (!other.TryGetComponent(out stateController)) return;
        if (stateController.PlayerState == Emotions.Sadness) return;
    }

    private void GetCaught(PlayerStateController stateController) {
        stateController.IsStateChangeBlcoked = true;
    }

    private void StartTrapEvent(PlayerStateController stateController) {
        stateController.IsStateChangeBlcoked = true;
    }
}
