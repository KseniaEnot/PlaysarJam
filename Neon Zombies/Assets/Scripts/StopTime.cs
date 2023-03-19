using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    [SerializeField]
    PlayerMove move;

    public float timer = 1;
    
    public void Update()
    {
        move.isInDialog = MonologueManager.isInDialogue;
        //Time.timeScale = timer;
        //Debug.Log(Time.timeScale);
        //if (MonologueManager.isInDialogue == true)
        //{
        //    timer = 0;
        //}
        //else
        //{
        //    timer = 1;
        //} 
    }
}
