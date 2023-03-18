using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DialogueTrigger : MonoBehaviour
{
    public string fileName;
    public bool isTriggeredByCollider = false;

    private bool WasTriggered = false;
    public void TriggerDialogue()
    {
        if (!WasTriggered)
            FindObjectOfType<MonologueManager>().StartMonologue(fileName);
        WasTriggered = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggeredByCollider || WasTriggered) return;
        TriggerDialogue();
    }
}
