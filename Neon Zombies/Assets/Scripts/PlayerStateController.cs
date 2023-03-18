using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] EmotionImage = new GameObject[3];
    [SerializeField]
    private float _stateColdown = 2f;
    [SerializeField]
    private float _overloadColdown = 3f;

    private Emotions _playerState = Emotions.Happiness;
    private float _stateColdownTimer = 0f;
    private float _overloadTimer = 0f;
    private bool _canChangeState = true;
    private Dictionary<Emotions, float> _emotionFillValue = new Dictionary<Emotions, float>();

    public bool IsStateChangeBlcoked = false;
    public bool IsOverloaded = false;
    [Header("Bar Scale Parameters")]
    [SerializeField] float increase = 0.1f;
    [SerializeField] float decrease = 0.05f;
    [SerializeField] float overloadDecrease = 0.2f;

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

    public event Action<Emotions> StateChanged;
    public event Action EmotionOverloaded;
    public event Action EmotionOverloadEnded;

    private void Awake()
    {
        EmotionOverloaded += OnEmotionOverload;

        foreach (Emotions emotionType in Enum.GetValues(typeof(Emotions)))
            _emotionFillValue.Add(emotionType, 0);
    }


    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
        UpdateOverloadTimer();
        ChangeStateOnInput();
        UpdateScale();
    }

    private void UpdateScale()
    {
        foreach (Emotions emotionType in Enum.GetValues(typeof(Emotions)))
        {
            if (emotionType == PlayerState)
            {
                if (!IsOverloaded)
                    _emotionFillValue[emotionType] = Mathf.Min(_emotionFillValue[emotionType] + increase * Time.deltaTime, 1f);
                else
                    _emotionFillValue[emotionType] = Mathf.Max(_emotionFillValue[emotionType] - overloadDecrease * Time.deltaTime, 0f);

                if (_emotionFillValue[emotionType] >= 1) { Debug.Log("Overload"); EmotionOverloaded.Invoke(); }
            }
            else _emotionFillValue[emotionType] = Mathf.Max(_emotionFillValue[emotionType] - decrease * Time.deltaTime, 0f);
        }

        
    }

    void ChangeStateOnInput()
    {
        Image image;
        Color tempColor;
        if (!_canChangeState || IsStateChangeBlcoked || IsOverloaded) return;


        if (Input.GetKeyDown(KeyCode.Alpha1) && PlayerState != Emotions.Happiness) { 
            PlayerState = Emotions.Happiness;
            EmotionImage[0].SetActive(false);
            EmotionImage[1].SetActive(true);
            EmotionImage[2].SetActive(false);
            image = EmotionImage[1].GetComponent<Image>();
            tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            _canChangeState = false;
            _stateColdownTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && PlayerState != Emotions.Fear)
        {
            PlayerState = Emotions.Fear;
            EmotionImage[0].SetActive(true);
            image = EmotionImage[0].GetComponent<Image>();
            tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            EmotionImage[1].SetActive(false);
            EmotionImage[2].SetActive(false);
            _canChangeState = false;
            _stateColdownTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && PlayerState != Emotions.Sadness)
        {
            PlayerState = Emotions.Sadness;
            EmotionImage[0].SetActive(false);
            EmotionImage[1].SetActive(false);
            EmotionImage[2].SetActive(true);
            image = EmotionImage[2].GetComponent<Image>();
            tempColor = image.color;
            tempColor.a = 1f;
            image.color = tempColor;
            _canChangeState = false;
            _stateColdownTimer = 0f;
        }

        if (!_canChangeState) StateChanged(PlayerState);
    }

    void UpdateTimer()
    {
        Image image;
        Color tempColor;
        if (_canChangeState) return;

        _stateColdownTimer += Time.deltaTime;

        if (_stateColdownTimer > _stateColdown) {
            switch (PlayerState)
            {
                case Emotions.Fear:
                    EmotionImage[1].SetActive(true);
                    EmotionImage[2].SetActive(true);
                    image = EmotionImage[1].GetComponent<Image>();
                    tempColor = image.color;
                    tempColor.a = 0.5f;
                    image.color = tempColor;
                    image = EmotionImage[2].GetComponent<Image>();
                    tempColor = image.color;
                    tempColor.a = 0.5f;
                    image.color = tempColor;
                    break;
                case Emotions.Happiness:
                    EmotionImage[0].SetActive(true);
                    EmotionImage[2].SetActive(true);
                    image = EmotionImage[0].GetComponent<Image>();
                    tempColor = image.color;
                    tempColor.a = 0.5f;
                    image.color = tempColor;
                    image = EmotionImage[2].GetComponent<Image>();
                    tempColor = image.color;
                    tempColor.a = 0.5f;
                    image.color = tempColor;
                    break;
                case Emotions.Sadness:
                    EmotionImage[0].SetActive(true);
                    EmotionImage[1].SetActive(true);
                    image = EmotionImage[1].GetComponent<Image>();
                    tempColor = image.color;
                    tempColor.a = 0.5f;
                    image.color = tempColor;
                    image = EmotionImage[0].GetComponent<Image>();
                    tempColor = image.color;
                    tempColor.a = 0.5f;
                    image.color = tempColor;
                    break;
                default:
                    break;
            }
            _canChangeState = true;
        }
    }

    private void UpdateOverloadTimer()
    {
        if (!IsOverloaded) return;

        _overloadTimer += Time.deltaTime;

        if (_overloadTimer > _overloadColdown) { 
            IsOverloaded = false; 
            _overloadTimer = 0;
            EmotionOverloadEnded.Invoke();
        }
    }

    private void OnEmotionOverload()
    {
        IsOverloaded = true;
    }

    public float EmotionFill(Emotions emotions) => _emotionFillValue[emotions];
}
