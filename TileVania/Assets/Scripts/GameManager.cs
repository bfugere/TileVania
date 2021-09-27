using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;

    void Awake()
    {
        int numberOfGameManagers = FindObjectsOfType<GameManager>().Length;

        // Singleton
        if (numberOfGameManagers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    public void HandlePlayerDeath()
    {
        if (playerLives > 1)
            RemoveLife();
        else
            ResetGameManager();
    }

    void RemoveLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ResetGameManager()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
