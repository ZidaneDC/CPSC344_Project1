//CPCS 344 - Level Design II, Chapman University, Fall 21
//Script reference : https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html 
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public string objectType;
    public GameObject collectionPrompt;
    public AudioManager audioManager;
    public UIManager uiManager;

    private PlayerInventory playerInventory;
    private bool canCollect;

    private void Start()
    {
        collectionPrompt.SetActive(false);
        canCollect = false;
    }

    private void Update()
    {
        if (canCollect)
        {
            //wait for player input, upon which the object will be destroyed and the object added to player inventory
            if (Input.GetKeyDown(KeyCode.E))
            {
                //send information to player inventory
                audioManager.playPickupSound();
                playerInventory.inventory.Add(objectType);
                //Debug.Log(objectType + " added to inventory.");
                //hide ui
                uiManager.HideInteractionPrompt();
                uiManager.SetLogText(objectType + " added to inventory.");
                Destroy(gameObject);
            }
        }
    }
    //updated version will display a UI popup upon player entering the trigger area
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            //Debug.Log("Entered object range.");
            canCollect = true;
            //display ui
            uiManager.DisplayInteractionPrompt();
            //find player script
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
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
