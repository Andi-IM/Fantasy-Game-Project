using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Class <c>FadeIn</c> membuat item akan menggelapkan nilai aplha color sehingga menjadi gelap.
/// </summary>
public class FadeInAnimation : MonoBehaviour
{
    [Header("Main Settings")] 
    public Image targetImage;
    public float fadeSpeed;
    
    void Awake()
    {
        // Membuat ukuran TargetImage sesuai dengan ukuran layar
        targetImage.rectTransform.localScale = new Vector2(Screen.width, Screen.height);
    }

    void FadeIn()
    {
        // Membuat warna TargetImage Menggunakan transisi Lerp dari warna awal ke warna transparan
        targetImage.color = Color.Lerp(targetImage.color, Color.clear, fadeSpeed * Time.deltaTime);
    }

    void Update()
    {
        FadeIn();
    }
}
