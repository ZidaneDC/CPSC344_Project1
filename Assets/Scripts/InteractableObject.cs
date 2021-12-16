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
    public GameObject audioObject;
    public AudioSource audioSource;
    public bool hasAudioClip;
    public AudioClip audioClip;

    private bool itemObtained = false; //will prevent player from constantly inspecting object and getting the item infinitely

    // Update is called once per frame
    void Update()
    {
        if (canInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                uiManager.HideInteractionPrompt();
                canInteract = false;

                if (itemObtained == false)
                {
                    if(item != "")
                    {
                        playerInventory.inventory.Add(item);
                    }
                    if (hasAudioClip)
                    {
                        audioSource.PlayOneShot(audioClip, 2);
                    }
                    itemObtained = true;
                    interactionText.StartInteraction(primaryText, item);
                    if(audioObject != null)
                    {
                        //audioObject.SetActive(false);
                    }
                }
                
                else if(itemObtained == true && secondaryText.Length != 0)
                {
                    interactionText.StartInteraction(secondaryText);
                }

                //else
                //{
                //    interactionText.StartInteraction(primaryText, item);
                //}
            }
        }
    }
}
