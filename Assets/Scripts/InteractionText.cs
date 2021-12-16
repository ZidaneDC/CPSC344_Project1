using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class InteractionText : MonoBehaviour
{
    public UIManager uiManager;
    
    private StarterAssetsInputs inputSystem;

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
        inputSystem = GameObject.Find("Player").GetComponentInChildren<StarterAssetsInputs>(); //FIX
    }

    public void StartInteraction(string[] sentences, string item)
    {
        inputSystem.cursorInputForLook = false; // FIX
        sentencesToDisplay = sentences;
        itemToObtain = item;
        sentenceCount = 0;
        displayedText.text = sentencesToDisplay[0];
        uiManager.DisplayInteractionText();
        //Debug.Log(displayedText.text);
    }

    public void StartInteraction(string[] sentences)
    {
        inputSystem.cursorInputForLook = false; // FIX
        sentencesToDisplay = sentences;
        itemToObtain = "";
        sentenceCount = 0;
        displayedText.text = sentencesToDisplay[0];
        uiManager.DisplayInteractionText();
        //Debug.Log(displayedText.text);
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
        //Debug.Log(displayedText.text);
    }

    public void EndInteraction()
    {
        uiManager.HideInteractionText();
        inputSystem.cursorInputForLook = true; //FIX
        displayedText.text = "";
        currSentence = "";
        sentenceCount = 0;
        if (itemToObtain != "")
        {
            uiManager.SetLogText(itemToObtain + " added to inventory.");
        }
    }
}
