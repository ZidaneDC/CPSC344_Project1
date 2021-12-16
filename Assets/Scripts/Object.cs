using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class Object : MonoBehaviour
{
    //base class all objects in the game will inherit from

    public string objectType;
    public UIManager uiManager;

    protected PlayerInventory playerInventory;
    protected InteractionText interactionText;
    protected StarterAssetsInputs inputSystem;
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
            inputSystem = other.gameObject.GetComponentInChildren<StarterAssetsInputs>();
            //make sure script was obtained
            //if (inputsystem != null)
            //{
            //    debug.log("obtained input system.");
            //}
        }
    }


    private void OnTriggerExit(Collider other)
    {
        playerInventory = null;
        canInteract = false;
        uiManager.HideInteractionPrompt();
    }
}
