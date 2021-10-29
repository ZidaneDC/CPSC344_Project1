using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheck : MonoBehaviour
{
    public GameObject interactionPrompt;
    public List<string> itemsNeeded = new List<string>();
    public GameObject successPopup;
    public GameObject failPopup;

    private PlayerInventory playerInventory;
    private bool canInteract;
    private bool canPass;

    private void Start()
    {
        canInteract = false;
        canPass = false;
        HideSuccessPopup();
        HideFailPopup();
    }
    private void Update()
    {
        if (canInteract)
        {
            //wait for player input, upon which the object will be destroyed and the object added to player inventory
            if (Input.GetKeyDown(KeyCode.E))
            {
                CheckInventory();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Entered object range.");
            canInteract = true;
            DisplayPrompt();
            //find player script
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            //make sure script was obtained
            if (playerInventory != null)
            {
                Debug.Log("Obtained player inventory.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        playerInventory = null;
        HidePrompt();
    }

    private void CheckInventory()
    {
        HidePrompt();
        Debug.Log("Checking player inventory....");
        foreach (string item in itemsNeeded)
        {
            if (playerInventory.inventory.Contains(item))
            {
                canPass = true;
            }

            else
            {
                canPass = false;
            }
        }

        if (canPass)
        {
            CheckPassed();
        }

        else
        {
            CheckFailed();
        }
    }

    private void CheckPassed()
    {
        Debug.Log("Check passed.");
        ShowSuccessPopup();
        Destroy(gameObject);
    }

    private void CheckFailed()
    {
        Debug.Log("Check failed. Items needed not found in player inventory.");
        ShowFailPopup();
    }
    private void DisplayPrompt()
    {
        interactionPrompt.SetActive(true);
    }

    private void HidePrompt()
    {
        interactionPrompt.SetActive(false);
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
}
