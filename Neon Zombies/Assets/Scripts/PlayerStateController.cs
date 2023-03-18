using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField]
    private float _stateColdown = 2f;

    private Emotions _playerState = Emotions.Happiness;
    private float _stateColdownTimer = 0f;
    private bool _canChangeState = true;

    public Emotions PlayerState
    {
        get
        {
            return _playerState;
        }

        set
        {
            _playerState = value;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        ChangeStateOnInput();
    }

    void ChangeStateOnInput()
    {
        if (!_canChangeState) return;


        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerState != Emotions.Happiness) { 
            PlayerState = Emotions.Happiness;
            _canChangeState = false;
            _stateColdownTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerState != Emotions.Fear)
        {
            PlayerState = Emotions.Fear;
            _canChangeState = false;
            _stateColdownTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerState != Emotions.Sadness)
        {
            PlayerState = Emotions.Sadness;
            _canChangeState = false;
            _stateColdownTimer = 0f;
        }
    }

    void UpdateTimer()
    {
        if (_canChangeState) return;

        _stateColdownTimer += Time.deltaTime;

        if (_stateColdownTimer > _stateColdown) _canChangeState = true;
    }

}
