using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class <c>LoadScene</c> akan memanggil scene lain masuk ke layar aktif
/// </summary>
public class LoadSceneDelay : MonoBehaviour
{
    [Header("Main Settings")] public string targetScene;
    public float delay;

    void LoadScene()
    {
        // Melakukan perpindahan antar scene yang aktif pada build settings.
        SceneManager.LoadScene(targetScene);
    }

    private void Start()
    {
        Invoke(nameof(LoadScene), delay);
    }
}