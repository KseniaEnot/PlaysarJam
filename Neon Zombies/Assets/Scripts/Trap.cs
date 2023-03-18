using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private float _timeInTrap = 10f;

    [SerializeField]
    private float _progressSize = 100f;

    [SerializeField]
    private float _progressOneTapPower = 10f;

    [SerializeField]
    private float _progressFallSpeed = 1f;

    private float _trapProgress = 0f;
    private float _trapTimer = 0f;

    private bool _isInTrap = false;

    PlayerStateController stateController;

    KeyboardInput input = KeyboardInput.getInstance();


    private void Update()
    {
        IntTrapEvent();
    }

    private void OnTriggerStay(Collider other)
    {

        if (!other.TryGetComponent(out stateController)) return;
        if (stateController.PlayerState == Emotions.Sadness) return;

        GetCaught();
    }

    private void GetCaught() {
        stateController.IsStateChangeBlcoked = true;
        _isInTrap = true;
    }

    private void IntTrapEvent()
    {
        if (!_isInTrap) return;

        if (input.getEbuttonDown()) _trapProgress += _progressOneTapPower;

        if (_trapProgress > _progressSize) GetOut();

        _trapProgress -= _progressFallSpeed * Time.deltaTime;
        if (_trapProgress < 0) _trapProgress = 0;


        _trapTimer += Time.deltaTime;
        if (_trapTimer > _timeInTrap) GetOut();
    }

    private void GetOut()
    {
        stateController.IsStateChangeBlcoked = false;
        _isInTrap = false;
        _trapTimer = 0f;
    }
}
