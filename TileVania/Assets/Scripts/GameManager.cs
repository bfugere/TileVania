using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] int playerScore = 0;

    [SerializeField] Text livesText;
    [SerializeField] Text scoreText;

    [SerializeField] float gameOverDelayTime = 3.5f;
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] [Range(0, 1)] float gameOverVolume = 0.1f;

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
        livesText.text = playerLives.ToString();
        scoreText.text = playerScore.ToString();
    }

    public void HandlePlayerDeath()
    {
        if (playerLives > 1)
            RemoveLife();
        else
            StartCoroutine(ResetGameManager());
    }

    public void AddToScore(int pointsToAdd)
    {
        playerScore += pointsToAdd;
        scoreText.text = playerScore.ToString();
    }

    void RemoveLife()
    {
        playerLives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

    IEnumerator ResetGameManager()
    {
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position, gameOverDelayTime);

        yield return new WaitForSecondsRealtime(gameOverDelayTime);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}
