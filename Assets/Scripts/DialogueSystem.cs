using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public UIManager uiManager;
    public List<string> sentences;
    private int sentenceCount;

    //public float textSpeed;


    // Start is called before the first frame update
    void Start()
    {
        uiManager.HideDialogueBox();
    }

    //Start Dialogue
    public void StartDialogue(string[] dialogue)
    {
        uiManager.ShowDialogueBox();
        //start coroutine here?
        sentences.Clear();
        sentenceCount = 0;

        foreach (string sentence in dialogue)
        {
            //sentences.Enqueue(sentence);
            sentences.Add(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentenceCount > sentences.Count)
        {
            uiManager.HideDialogueBox();
            uiManager.dialogueText.text = "";
        }

        uiManager.dialogueText.text = sentences[sentenceCount];
        //wait for input or amount of time  via coroutine
        DisplayNextSentence();
    }
}
