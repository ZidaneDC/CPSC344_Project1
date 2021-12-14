using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractableObject : Object
{
    //this class is for objects that when interacted with, display dialogue ui/information and don't destroy themselves after

    //add variable reference to future dialogue UI class here

    public string item;
    [TextArea(3, 10)]
    public string[] primaryText;
    [TextArea(3, 10)]
    public string[] secondaryText; // IF itemObtained is set to true, a different bit of text will be displayed on interaction
    public GameObject audioSource;

    private bool itemObtained = false; //will prevent player from constantly inspecting object and getting the item infinitely

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                uiManager.HideInteractionPrompt();

                if (itemObtained == false)
                {
                    playerInventory.inventory.Add(item);
                    itemObtained = true;
                    interactionText.StartInteraction(primaryText, item);
                    audioSource.SetActive(false);
                }
                
                else if(itemObtained == true && secondaryText.Length != 0)
                {
                    interactionText.StartInteraction(secondaryText);
                }

                else
                {
                    interactionText.StartInteraction(primaryText, item);
                }
            }
        }
    }
}
