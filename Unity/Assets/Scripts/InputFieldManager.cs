using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputFieldManager : MonoBehaviour
{
    private TesingChats chatScript;
    private TMP_InputField thisInputField;
    private void Start()
    {
        thisInputField = GetComponent<TMP_InputField>();
        chatScript = FindObjectOfType<TesingChats>();

        if (chatScript == null)
        {
            chatScript = FindObjectOfType<TesingChats>();
        }
    }

    public void SubmitTheTextWithKey()
    {
        chatScript.submitText(chatScript.inputchat.text);
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (!thisInputField.isFocused)
            {
                thisInputField.Select();
            }
        }
    }
}
