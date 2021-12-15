using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class UIManager : MonoBehaviour
{
    public float waitTime;

    public GameObject successPopup;
    public GameObject failPopup;
    public GameObject miniGamePopup;
    public GameObject interactionPrompt;
    public GameObject actionLog;
    public Text logText;
    public GameObject interactionTextBox;
    public Text interactionText;
    public GameObject notePopup;

    public GameObject minigame;

    protected StarterAssetsInputs inputSystem;

    // Start is called before the first frame update
    void Start()
    {
        successPopup.SetActive(false);
        failPopup.SetActive(false);
        HideMinigamePopup();
        HideInteractionPrompt();
        actionLog.SetActive(false);
        HideInteractionText();
        ShowNotePopUp();

        inputSystem = GameObject.Find("Player").GetComponentInChildren<StarterAssetsInputs>();
    }

    private void Update()
    {
        if(successPopup.activeInHierarchy == true || failPopup.activeInHierarchy == true || notePopup.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                HideFailPopup();
                HideSuccessPopup();
                HideNotePopUp();
            }
        }

        //specific for minigame popup
        if (miniGamePopup.activeInHierarchy)
        {
            //Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                HideMinigamePopup();
                Time.timeScale = 1;
                minigame.GetComponent<MiniGameManager>().revertEnteredCode();
            }
        }
    }

    public void SetLogText(string logMessage)
    {
        logText.text = logMessage;
        StartCoroutine("TimedUIPopup", actionLog);
    }

    //activate a bit of ui/a game object for a set amount of time
    private IEnumerator TimedUIPopup(GameObject toEnable)
    {
        Debug.Log("Coroutine Activated.");
        toEnable.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        toEnable.SetActive(false);
    }

    public void HideFailPopup()
    {
        failPopup.SetActive(false);
        inputSystem.cursorInputForLook = true;
    }

    public void ShowFailPopup()
    {
        failPopup.SetActive(true);
        inputSystem.cursorInputForLook = false;
    }

    public void HideSuccessPopup()
    {
        successPopup.SetActive(false);
        inputSystem.cursorInputForLook = true;
    }

    public void ShowSuccessPopup()
    {
        successPopup.SetActive(true);
        inputSystem.cursorInputForLook = false;
    }

    public void ShowMinigamePopup()
    {
        miniGamePopup.SetActive(true);
    }

    public void HideMinigamePopup()
    {
        miniGamePopup.SetActive(false);
    }

    public void DisplayInteractionPrompt()
    {
        interactionPrompt.SetActive(true);
    }

    public void HideInteractionPrompt()
    {
        interactionPrompt.SetActive(false);
    }

    public void DisplayInteractionText()
    {
        interactionTextBox.SetActive(true);
    }

    public void HideInteractionText()
    {
        interactionTextBox.SetActive(false);
    }

    public void ShowNotePopUp()
    {
        notePopup.SetActive(true);
    }

    public void HideNotePopUp()
    {
        notePopup.SetActive(false);
    }
}
