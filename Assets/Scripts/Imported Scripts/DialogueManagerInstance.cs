using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerInstance : MonoBehaviour
{
    private TypeWriterEffect typeWriterEffect;
    private string currLevelToLoad;

    private static DialogueManagerInstance dialogueInstance;

    public GameObject dialogueUI;
    //public GameObject optionsUI;

    public Text dialogueBox;
    public string[] dialogueToPrint; 

    //public GameObject transitionObject;
    //public Animator sceneTransition;
    //public float sceneTransitionTime = 3.05f;

    //public static DialogueManagerInstance Instance //for creating instance
    //{
    //    get { return dialogueInstance; }
    //}

    //private void Awake() //creates instance
    //{
    //    if (dialogueInstance != null && dialogueInstance != this)
    //    {
    //        Destroy(this.gameObject);
    //        return;
    //    }

    //    dialogueInstance = this;
    //    DontDestroyOnLoad(this.gameObject); //prevents object from being destroyed on scene reload
    //}

    // Start is called before the first frame update
    void Start()
    {
        typeWriterEffect = GetComponent<TypeWriterEffect>();
        StartCoroutine(StepThroughDialogue());
    }
    IEnumerator StepThroughDialogue()
    {
        int i = 0;
        foreach (string dialogue in dialogueToPrint)
        {
            yield return typeWriterEffect.Run(dialogue, dialogueBox);
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
            if (i >= dialogueToPrint.Length)
            {
                //SceneManager.LoadScene(npcSpeaking.levelToLoad);
                HideDialogueUI();
                LevelLoad();
            }

           i = i++;
        }

      
    }

    //public void ShowDialogueUI(NpcController npcSpeaking)
    //{
    //    npcController = npcSpeaking;
    //    npcInfo = npcSpeaking.npcInfo;
    //    npcName.text = npcSpeaking.npcInfo.npcName;
    //    dialogueUI.SetActive(true);
    //    StartCoroutine(StepThroughDialogue());
    //    playerMove.StopMovement();
    //}

    void HideDialogueUI()
    {
        //Debug.Log("Conversation Ended.");
        dialogueUI.SetActive(false);
        dialogueBox.text = string.Empty;
    }


    public void LevelLoad()
    {
        //StartCoroutine(LevelLoadAndTransition()); //TURN BACK ON ONCE WE HAVE AN ANIMATION
        SceneManager.LoadScene(currLevelToLoad);
    }

    //IEnumerator LevelLoadAndTransition()
    //{
    //    //TURN BACK ON ONCE WE HAVE AN ANIMATION
    //    //transitionObject.SetActive(true);

    //    //yield return new WaitForSeconds(2.07f);

    //    //sceneTransition.SetTrigger("Start");
    //    //play animation

    //    //wait
    //    //yield return new WaitForSeconds(.5f);

    //    //load level
    //    SceneManager.LoadScene(currLevelToLoad);
    //}
}
