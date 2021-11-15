using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Object
{
    //this class is for objects that when interacted with, display dialogue ui/information and don't destroy themselves after

    //add variable reference to future dialogue UI class here

    //possible secondary item that can still be picked up?
    public string item;
    public string[] interactionText;
    public string[] secondaryText; // IF itemObtained is set to true, a different bit of text will be displayed on interaction
    private bool itemObtained = false; //will prevent player from constantly inspecting object and getting the item infinitely

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                uiManager.HideInteractionPrompt();
                //DISPLAY DIALOGUE UI
                if (item != null)
                {
                    playerInventory.inventory.Add(item);
                    itemObtained = true;
                }

                //HIDE DIALOGUE UI
                uiManager.SetLogText(objectType + " added to inventory.");
            }
        }
    }
}
