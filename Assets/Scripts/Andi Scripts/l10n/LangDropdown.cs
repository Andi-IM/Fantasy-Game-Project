using System;
using UnityEngine;
using UnityEngine.UI;

public class LangDropdown : MonoBehaviour
{
    static public Action<int> ChangeLanguage;
    public Dropdown dropdown;
    public Text label;

    public void LanguageChanged()
    {
        if (ChangeLanguage != null) 
            ChangeLanguage(dropdown.value);

        dropdown.captionText.text = CVSParser.GetAvailableLanguages()[dropdown.value];
        label.text = dropdown.captionText.text;
    }

    void PopulateDropdown()
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(CVSParser.GetAvailableLanguages());
        LanguageChanged();
    }
    void Start()
    {
        
    }
}
