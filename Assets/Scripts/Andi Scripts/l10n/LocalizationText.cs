using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizationText : MonoBehaviour
{
    public string key;

    private void OnEnable()
    {
        LangDropdown.ChangeLanguage += ChangeLanguage;
    }

    private void OnDisable()
    {
        LangDropdown.ChangeLanguage += ChangeLanguage;
    }

    void Start()
    {
        ChangeLanguage(0);
    }
    
    private void ChangeLanguage(int index)
    {
        gameObject.GetComponent<Text>().text = CVSParser.GetTextFromId(key, index);
    }
}
