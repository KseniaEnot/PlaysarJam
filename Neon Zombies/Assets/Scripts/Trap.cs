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
    private bool _isAlreadyTrapped = false;

    PlayerStateController _stateController;
    PlayerMove _playerMove;

    KeyboardInput input = KeyboardInput.getInstance();


    private void Update()
    {
        IntTrapEvent();
    }

    private void OnTriggerStay(Collider other)
    {

        if (!other.TryGetComponent(out _stateController)) return;
        if (!other.TryGetComponent(out _playerMove)) return;
        if (_stateController.PlayerState == Emotions.Sadness) return;
        if (_isAlreadyTrapped) return;

        GetCaught();
    }

    private void OnTriggerExit(Collider other)
    {
        _isAlreadyTrapped = false;
    }

    private void GetCaught() {
        _stateController.IsStateChangeBlcoked = true;
        _playerMove.isInTrap = true;
        _isInTrap = true;
        _isAlreadyTrapped = true;
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
        _stateController.IsStateChangeBlcoked = false;
        _isInTrap = false;
        _playerMove.isInTrap = false;
        _trapTimer = 0f;
        _trapProgress = 0f;
    }
}
