using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderToText : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    private Slider slider;

    private void Start()
    {
        if (text.gameObject == null)
        {
            text = GetComponentInChildren<TMP_Text>();
        }

        slider = GetComponent<Slider>();

        slider.onValueChanged.AddListener(delegate { ChangeText(); });

        ChangeText();
    }

    void ChangeText()
    {
        text.text = slider.value.ToString();
    }
}