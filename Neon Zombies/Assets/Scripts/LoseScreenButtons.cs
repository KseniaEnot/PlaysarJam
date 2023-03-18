using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LoseScreenButtons : MonoBehaviour
{
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("Level");
    }
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
