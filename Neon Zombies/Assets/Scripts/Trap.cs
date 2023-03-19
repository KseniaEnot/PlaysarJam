using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private Image _progressBar;

    [SerializeField]
    private GameObject _text;

    [SerializeField]
    private LilTrap[] _lilTraps;

    [SerializeField]
    private Animator[] _lilTrapsAnimators;

    [SerializeField]
    private SoundContorol soundControll;

    private int textScroller = -1;

    [SerializeField]
    private GameObject QTE;

    private float _trapProgress = 0f;
    private float _trapTimer = 0f;

    private bool _isInTrap = false;
    private bool _isAlreadyTrapped = false;

    PlayerStateController _stateController;
    PlayerMove _playerMove;

    KeyboardInput input = KeyboardInput.getInstance();

    private void Start()
    {
        foreach(LilTrap lilTrap in _lilTraps)
        {
            lilTrap.onLilTrapStay += OnLilTrapTriggerStay;
        }
    }


    private void Update()
    {
        IntTrapEvent();
    }

    private void OnLilTrapTriggerStay(Collider other)
    {

        if (!other.TryGetComponent(out _stateController)) return;
        if (!other.TryGetComponent(out _playerMove)) return;
        if (_stateController.PlayerState == Emotions.Sadness) return;
        if (_isAlreadyTrapped) return;

        GetCaught();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isAlreadyTrapped) return;
        _isAlreadyTrapped = false;

        foreach (Animator lilTrapAnimator in _lilTrapsAnimators)
        {
            lilTrapAnimator.SetBool("isOpen", true);
        }
        soundControll.PlayTraptOpen();
    }

    private void GetCaught() {

        foreach (Animator lilTrapAnimator in _lilTrapsAnimators)
        {
            lilTrapAnimator.SetBool("isOpen", false);
        }

        soundControll.PlayTrapt();


        _stateController.IsStateChangeBlcoked = true;
        _playerMove.isInTrap = true;
        _isInTrap = true;
        _isAlreadyTrapped = true;
        ChangeActivity(true);
    }

    private void IntTrapEvent()
    {
        if (!_isInTrap) return;

        if (input.getEbuttonDown()) _trapProgress += _progressOneTapPower;

        if (_trapProgress > _progressSize) GetOut();

        _trapProgress -= _progressFallSpeed * Time.deltaTime;
        if (_trapProgress < 0) _trapProgress = 0;

        ChangeProgress(1 - _trapProgress / _progressSize);

        if (_text.GetComponent<TextMeshProUGUI>().fontSize>120)
            textScroller = -1;
        else if (_text.GetComponent<TextMeshProUGUI>().fontSize<70)
            textScroller = 1;

        _text.GetComponent<TextMeshProUGUI>().fontSize += textScroller;
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

        ChangeActivity(false);
    }

    private void ChangeProgress(float progress)
    {
        _progressBar.fillAmount = progress;
    }

    private void ChangeActivity(bool isActive)
    {
        QTE.SetActive(isActive);
    }
}
