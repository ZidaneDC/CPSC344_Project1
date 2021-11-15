using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheck : Object
{
    public List<string> itemsNeeded = new List<string>();
    public AudioManager audioManager;

    private bool canPass = false;

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

    private void CheckInventory()
    {
        uiManager.HideInteractionPrompt();
        //Debug.Log("Checking player inventory....");
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
        //Debug.Log("Check passed.");
        audioManager.playSuccessSound();
        uiManager.ShowSuccessPopup();
        Destroy(gameObject);
    }

    private void CheckFailed()
    {
        //Debug.Log("Check failed. Items needed not found in player inventory.");
        audioManager.playErrorSound();
        uiManager.ShowFailPopup();
    }
}
