using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
{
   [SerializeField] private float writeSpeed = 40f;
   public Coroutine Run(string textToType, Text textbox)
    {
        return StartCoroutine(TypeText(textToType, textbox));
    }

    private IEnumerator TypeText(string textToType, Text textbox)
    {
        textbox.text = string.Empty;

        float t = 0;
        int charIndex = 0;

        yield return new WaitForSeconds(.1f);

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * writeSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textbox.text = textToType.Substring(0, charIndex);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                break;
            }
            yield return null;
        }

        textbox.text = textToType;
        yield return new WaitForSeconds(.1f);
    }
}
