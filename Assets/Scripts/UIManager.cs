using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject successPopup;
    public GameObject failPopup;
    public GameObject miniGamePopup;
    public GameObject interactionPrompt;

    // Start is called before the first frame update
    void Start()
    {
        HideSuccessPopup();
        HideFailPopup();
        HideMinigamePopup();
    }

    private void Update()
    {
        if(successPopup.activeInHierarchy == true || failPopup.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                HideFailPopup();
                HideSuccessPopup();
            }
        }

        //specific for minigame popup
        if (miniGamePopup.activeInHierarchy)
        {
            Time.timeScale = 0;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                HideMinigamePopup();
                Time.timeScale = 1;
            }
        }
    }

    public void HideFailPopup()
    {
        failPopup.SetActive(false);
    }

    public void ShowFailPopup()
    {
        failPopup.SetActive(true);
    }

    public void HideSuccessPopup()
    {
        successPopup.SetActive(false);
    }

    public void ShowSuccessPopup()
    {
        successPopup.SetActive(true);
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

}
