using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public UIManager uiManager;
    public Text displayedText;

    private string[] sentencesToDisplay;
    private string currSentence;
    private int sentenceCount;
    // Start is called before the first frame update
    void Start()
    {
        displayedText.text = "";
    }

    public void StartInteraction(string[] sentences)
    {
        uiManager.DisplayInteractionText();
        //clear sentencesToDisplay
    }
}
