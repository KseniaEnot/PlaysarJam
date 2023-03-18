using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicControl : MonoBehaviour
{
    public static MusicControl Instanse;
    void Awake()
    {

        if (Instanse == null)
        {
            GetComponent<AudioSource>().Play();
            Instanse = this;
        }
    }
}
