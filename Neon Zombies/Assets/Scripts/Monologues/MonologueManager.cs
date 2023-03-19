using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonologueManager : MonoBehaviour
{
    TextMeshProUGUI dialogueText;
    [SerializeField] GameObject panel;
    [SerializeField] float typingSpeed;
    private Queue<string> sentences;
   
    static public  bool isInDialogue = false;

    private void Update()
    {
        if (sentences == null || !isInDialogue) return;

        if (Input.GetKeyDown(KeyCode.Space)) DiaplayNextSentence();
    }

    public void StartMonologue(string name)
    {
        Debug.Log("Starting Conversation");
        //animator.SetBool("IsOpen", true);
        //sentences.Clear();
        sentences = new Queue<string>();

        dialogueText = panel.GetComponentInChildren<TextMeshProUGUI>();
        panel.SetActive(true);

        TextAsset mytxtData = (TextAsset)Resources.Load(name);
        Debug.Log(mytxtData);

        var arrayString = mytxtData.text.Split('\n');
        foreach (var line in arrayString)
        {
            sentences.Enqueue(line);
        }
        isInDialogue = true;

        DiaplayNextSentence();
    }

    public void DiaplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = sentence;
        /*foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }*/
        yield return null;
        //yield return new WaitForSeconds(4);
        //DiaplayNextSentence();
    }

    public void EndDialogue()
    {

        StopAllCoroutines();
        sentences.Clear();
        isInDialogue = false;
        panel.SetActive(false);
    }
}
