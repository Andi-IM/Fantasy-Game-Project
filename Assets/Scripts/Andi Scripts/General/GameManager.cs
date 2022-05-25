using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance;

    [Header("GameSettings")]
    public bool isFirst = false;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        
    }
}