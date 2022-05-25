using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>FadeOut</c> membuat item akan menggelapkan nilai aplha color dari transparan hingga terlihat.
/// </summary>
public class FadeOutAnimation : MonoBehaviour
{
    [Header("Main Settings")] 
    public Image targetImage;
    public float fadeSpeed;
    public float delay;
    private bool _isStartFadeOut;

    void Awake()
    {
        // Membuat TargetImage sesuai dengan ukuran layar
        targetImage.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
        
        // Menyembunyikan TargetImage
        targetImage.enabled = false;
        targetImage.color = Color.clear;
    }

    void Start()
    {
        // Memanggil fungsi StartFadeOut berdasarkan delay
        Invoke("StartFadeOut", delay);
    }


    void StartFadeOut()
    {
        // Mengubah nilai StartFadeOut menjadi true
        _isStartFadeOut = true;
        
        // Memunculkan TargetImage dari canvas;
        targetImage.enabled = true;
    }

    void FadeOut()
    {
        // Membuat warna dari TargetImage menggunakan transisi Lerp dari transparan ke warna dasar gambar;
        targetImage.color = Color.Lerp(targetImage.color, Color.black, fadeSpeed * Time.deltaTime);
    }

    void Update()
    {
        if (_isStartFadeOut)
        {
            FadeOut();
        }
    }
}
