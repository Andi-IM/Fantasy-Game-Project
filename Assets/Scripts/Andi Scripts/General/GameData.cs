using System;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance;

    public bool isFirst;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else 
            Instance = this;
        
        DontDestroyOnLoad(gameObject);
    }
}