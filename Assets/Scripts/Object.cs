using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    //base class all objects in the game will inherit from

    public string objectType;
    public UIManager uiManager;

    protected PlayerInventory playerInventory;
    protected InteractionText interactionText;
    protected bool canInteract = false;

    //display a UI popup upon player entering the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //Debug.Log("Entered object range.");
            canInteract = true;
            //display ui
            uiManager.DisplayInteractionPrompt();
            //find player script
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            interactionText = other.gameObject.GetComponent<InteractionText>();
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
