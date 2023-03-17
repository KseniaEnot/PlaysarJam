using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject background;
    public GameObject SettingsField;
    bool settings = false;
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        settings = true;
        background.SetActive(false);
        SettingsField.SetActive(true);
       
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && settings == true)
        {
            SettingsField.SetActive(false);
            background.SetActive(true);
            settings = false;
        }
    }
}
