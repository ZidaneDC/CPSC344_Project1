using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject successPopup;
    public GameObject failPopup;

    // Start is called before the first frame update
    void Start()
    {
        HideSuccessPopup();
        HideFailPopup();
    }

    private void Update()
    {
        if(successPopup.activeInHierarchy == true || failPopup.activeInHierarchy == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                HideFailPopup();
                HideSuccessPopup();
            }
        }
    }

    public void HideFailPopup()
    {
        failPopup.SetActive(false);
    }

    public void ShowFailPopup()
    {
        failPopup.SetActive(true);
    }

    public void HideSuccessPopup()
    {
        successPopup.SetActive(false);
    }

    public void ShowSuccessPopup()
    {
        successPopup.SetActive(true);
    }
}
