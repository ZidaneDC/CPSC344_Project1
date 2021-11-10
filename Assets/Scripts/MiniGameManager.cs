using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public UIManager uiManager;
    public Text enteredCode;
    public string desiredCode = "1234";
    

    // Start is called before the first frame update
    void Start()
    {
        enteredCode.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //check if four digits have been entered (code is 4 digits)
        if(enteredCode.text.Length == 4)
        {
            //code is correct, show player that the codse is valid/correct
            if(enteredCode.text == desiredCode)
            {
                enteredCode.text = "VALID";
            }
            //else, code is entered incorrectly
            else
            {
                enteredCode.text = "INVALID";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            uiManager.ShowMinigamePopup();

        }
    }

    public void OnButtonTap(Text text)
    {
        //on button tap, concatenate a string to show the digit the user selected to tap
        enteredCode.text = enteredCode.text + text;
    }
}
