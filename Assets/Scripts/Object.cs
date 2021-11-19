using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //base class all objects in the game will inherit from

    public string objectType;
    public UIManager uiManager;

    protected PlayerInventory playerInventory;
    protected DialogueSystem dialogueController;
    protected bool canInteract = false;


    //display a UI popup upon player entering the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Entered object range.");
            canInteract = true;
            //display ui
            uiManager.ShowInteractionPrompt();
            //find player script
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            dialogueController = other.gameObject.GetComponent<DialogueSystem>();
            //make sure script was obtained
            //if (playerInventory != null)
            //{
            //    Debug.Log("Obtained player inventory.");
            //}
        }
    }


    private void OnTriggerExit(Collider other)
    {
        playerInventory = null;
        uiManager.HideInteractionPrompt();
    }
}
