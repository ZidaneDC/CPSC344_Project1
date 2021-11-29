using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public UIManager uiManager;
   
    private Text displayedText;
    private string itemToObtain;
    private string[] sentencesToDisplay;
    private string currSentence;
    private int sentenceCount;
    // Start is called before the first frame update
    void Start()
    {
        displayedText = uiManager.interactionText;
        displayedText.text = "";
    }

    public void StartInteraction(string[] sentences, string item)
    {
        uiManager.DisplayInteractionText();
        sentencesToDisplay = sentences;
        itemToObtain = item;
        sentenceCount = 0;
        displayedText.text = sentencesToDisplay[0];
    }

    public void StartInteraction(string[] sentences)
    {
        uiManager.DisplayInteractionText();
        sentencesToDisplay = sentences;
        itemToObtain = "";
        sentenceCount = 0;
        displayedText.text = sentencesToDisplay[0];
    }

    public void DisplayNextSentence() //will be called by button click
    {
        sentenceCount += 1;
        //check to see if end of array has been reached, if it has call EndInteraction and return
        if (sentenceCount >= sentencesToDisplay.Length)
        {
            EndInteraction();
            return;
        }
        //if not the end of the array, update text to next sentence
        displayedText.text = sentencesToDisplay[sentenceCount];
    }

    public void EndInteraction()
    {
        uiManager.HideInteractionText();
        displayedText.text = "";
        if(itemToObtain != "")
        {
            uiManager.SetLogText(itemToObtain + " added to inventory.");
        }
    }
}
