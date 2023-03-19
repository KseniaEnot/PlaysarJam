using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] List<GameObject> gameObjectsToHide;
    [SerializeField] GameObject mask;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject cutsceneCamera;
    [SerializeField] GameObject winPanel;
    [SerializeField] MusicControl music;

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameCountdown>().currentTimer = 6000f;
        music.PlayWin();

        foreach (GameObject gameObject in gameObjectsToHide)
            gameObject.SetActive(false);

        StartCutscene();
    }

    private void StartCutscene()
    {
        mainCamera.SetActive(false);
        cutsceneCamera.SetActive(true);
        mask.GetComponentInParent<PlayerStateController>().enabled = false;
        mask.GetComponentInParent<PlayerMove>().enabled = false;
        mask.GetComponentInParent<Animator>().SetTrigger("isHappy");
        mask.transform.parent.transform.rotation = new Quaternion(0, 0, 0, 0);
        StartCoroutine(fogDissipate());
        StartCoroutine(WearHat());
        StartCoroutine(RunIntoTheSun());
    }

    IEnumerator fogDissipate()
    {
        float time = 0f;
        while (time < 2f)
        {
            time += Time.deltaTime;
            mask.gameObject.transform.localScale += Vector3.one * Time.deltaTime * 5f;
            yield return null;
        }
    }

    IEnumerator WearHat()
    {
        float time = 0f;
        while (time < 3f)
        {
            time += Time.deltaTime;
            //get a hat
            yield return null;
        }

    }

    IEnumerator RunIntoTheSun()
    {
        float time = 0f;
        transform.forward = Vector3.zero;
        while (time < 5f)
        {
            time += Time.deltaTime;
            //walk away
            mask.GetComponentInParent<PlayerMove>().controller.Move(new Vector3(0, 0, 1) * 1f * Time.deltaTime);
            yield return null;
        }
        //open win panel
        winPanel.SetActive(true);
    }
}
