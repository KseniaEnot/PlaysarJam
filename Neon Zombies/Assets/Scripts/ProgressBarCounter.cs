using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ProgressBarCounter : MonoBehaviour
{
    [SerializeField]
    static private Image _progressBar;
    static private GameObject thisObject;
    // Start is called before the first frame update
    void Start()
    {
        thisObject = gameObject;
    }

    public static void ChangeProgress(float progress)
    {
        _progressBar.fillAmount = progress;
    }

    public static void ChangeActivity(bool isActive)
    {
        thisObject.SetActive(isActive);
    }
}
