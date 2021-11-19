using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Object
{
    //this class is for objects that when interacted with, display dialogue ui/information and don't destroy themselves after

    //add variable reference to future dialogue UI class here

    //possible secondary item that can still be picked up?
    public string item;
    [TextArea(3, 10)]
    public string[] interactionText;
    [TextArea(3, 10)]
    public string[] secondaryText; // IF itemObtained is set to true, a different bit of text will be displayed on interaction
    //potentially an image display for stuff like the id card and cubicle labels

    private bool itemObtained = false; //will prevent player from constantly inspecting object and getting the item infinitely

    // Update is called once per frame
    void Update()
    {
        if (canInteract && Input.GetKeyDown(KeyCode.E))
        {
            uiManager.HideInteractionPrompt();
            //DISPLAY DIALOGUE UI
            if (itemObtained == false || item == null)
            {
                playerInventory.inventory.Add(item);
                itemObtained = true;
                //start dialogue with first set of sentences
                dialogueController.StartDialogue(interactionText);
            }
            else
            {
                itemObtained = true;
                //start dialogue with second set of sentences
                dialogueController.StartDialogue(secondaryText);
            }

            uiManager.SetLogText(item + " added to inventory.");
            //HIDE DIALOGUE UI
        }
    }
}
