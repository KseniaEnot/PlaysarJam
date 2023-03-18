using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //переменные главного меню
    public GameObject BackgroundUI;
    public GameObject SettingsUI;
    bool settings = false;

    //переменные меню паузы
    public GameObject PauseUI;
    public GameObject PauseSettingsUI;
    bool pausesettings = false;
    public bool isPause = false;
    public float timer = 1;

    //функции главного меню
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void Settings()
    {
        settings = !settings;
        BackgroundUI.SetActive(!settings);
        SettingsUI.SetActive(settings);
       
    }
    public void Exit()
    {
        Application.Quit();
    }
    //функции меню паузы
    public void Continue()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        timer = 1;
    }
    public void PauseSettings()
    {
        pausesettings = true;
        PauseUI.SetActive(false);
        PauseSettingsUI.SetActive(true);
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
 
    public void Update()
    {
        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && settings == true)
        {
            SettingsUI.SetActive(false);
            BackgroundUI.SetActive(true);
            settings = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape) && pausesettings == true)
        {
            PauseSettingsUI.SetActive(false);
            PauseUI.SetActive(true);
            pausesettings = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == true)
        {
            PauseUI.SetActive(false);
            timer = 1;
            isPause = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPause == false)
        {
            PauseUI.SetActive(true);
            timer = 0;
            isPause = true;
        }
    }
}
