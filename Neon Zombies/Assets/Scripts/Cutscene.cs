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

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<GameCountdown>().currentTimer = 6000f;

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
        StartCoroutine(fogDissipate());
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
        /*time = 0f;
        while (time < 2f)
        {
            time += Time.deltaTime;
            //get a hat
            yield return null;
        }*/
        time = 0f;
        transform.forward = Vector3.zero;
        while (time < 3f)
        {
            time += Time.deltaTime;
            //walk away
            mask.GetComponentInParent<PlayerMove>().controller.Move(new Vector3(0, 0, 1) * 2f * Time.deltaTime);
            yield return null;
        }

        //open win panel
    }
}
