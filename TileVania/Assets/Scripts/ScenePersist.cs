using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingSceneIndex;

    void Awake()
    {
        int numberOfScenePersist = FindObjectsOfType<ScenePersist>().Length;

        // Singleton
        if (numberOfScenePersist > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        startingSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex != startingSceneIndex)
            Destroy(gameObject);
    }
}
