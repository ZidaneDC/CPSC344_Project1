using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    //private Keyboard kb;

    public Animator animator;
    public Text nameText;
    public Text dialogueText;

    public float textSpeed;
    public float fastTextSpeed;

    public GameObject continueButton;
    public GameObject startButton;

    // Start is called before the first frame update
    void Start()
    {
        //kb = InputSystem.GetDevice<Keyboard>();
        sentences = new Queue<string>();
        continueButton.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue) //on start button press, the button will deactivate and the dialogue ui will apppear
    {
        startButton.SetActive(false);
        animator.SetBool("IsOpen", true);
        continueButton.SetActive(true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); 
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() //on continue button press, this activates
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence) //coroutine that controls text typing
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (!Input.GetKeyDown("space"))//kb.spaceKey.wasPressedThisFrame
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);
                
            }
            else
            {
                //dialogueText.text += letter;
                //yield return new WaitForSeconds(fastTextSpeed);
                dialogueText.text = sentence;
                yield break;
            }
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
