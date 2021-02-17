using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    private Button thisButton;

    private void Start()
    {
        thisButton = GetComponent<Button>();

        thisButton.onClick.AddListener(PlaySoundClick);

    }

    private void OnMouseOver()
    {
        Debug.Log("aaaa");
    }

    void PlaySoundClick()
    {

    }
}