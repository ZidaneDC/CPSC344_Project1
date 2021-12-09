using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameManager : MonoBehaviour
{
    public UIManager uiManager;
    public AudioManager audManager;
    public Text enteredCode;
    public string desiredCode = "1234";
    public GameObject door;
    public bool codeCracked = false;
    

    // Start is called before the first frame update
    void Start()
    {
        enteredCode.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //check for key pad input
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            enteredCode.text += "0";
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enteredCode.text += "1";
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enteredCode.text += "2";
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            enteredCode.text += "3";
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            enteredCode.text += "4";
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            enteredCode.text += "5";
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            enteredCode.text += "6";
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            enteredCode.text += "7";
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            enteredCode.text += "8";
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            enteredCode.text += "9";
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            enteredCode.text += "*";
        }
        if (Input.GetKeyDown(KeyCode.Hash))
        {
            enteredCode.text += "#";
        }

        //check if four digits have been entered (code is 4 digits)
        if (enteredCode.text.Length >= 4)
        {
            //code is correct, show player that the code is valid/correct
            if (enteredCode.text == desiredCode)
            {
                Debug.Log("code is correct!");
                enteredCode.text = "VALID";
                codeCracked = true;
                door.SetActive(false);
                audManager.playSuccessSound();
            }
            else
            {
                if (door.activeInHierarchy)
                {
                    enteredCode.text = "INVALID";
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!codeCracked)
        {
            if (other.gameObject.tag == "Player")
            {
                uiManager.ShowMinigamePopup();
            }
        }
    }

    //concatenate entered code string with the text on the button object
    public void OnButtonClick(Text textString)
    {
        enteredCode.text += textString.text;
        Debug.Log("You've entered: " + textString.text);
        Debug.Log("Code is: " + enteredCode.text);
        Debug.Log("Length: " + enteredCode.text.Length);
    }


    public void revertEnteredCode() {
        Debug.Log("Reverting code");
        enteredCode.text = "";
    }
}
