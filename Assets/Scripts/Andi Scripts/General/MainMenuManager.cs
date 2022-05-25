using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Panel List")] 
    public GameObject mainPanel;
    public GameObject tutorialPanel;
    
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        tutorialPanel.SetActive(false);
    }

    public void StartButton()
    {
        if (GameData.Instance.isFirst)
        {
            tutorialPanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene("3. Gameplay");
        }
    }

    public void AccessShop()
    {
        SceneManager.LoadScene("6. Shop");
    }

    public void AccessOption()
    {
        SceneManager.LoadScene("5. Settings");
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene("4. Credits");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
