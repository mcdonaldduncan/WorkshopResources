using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string nextLevelName;

    Enemy[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = FindObjectsOfType<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemiesAreAllDead())
            GoToNextLevel();
    }

    bool EnemiesAreAllDead()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to level " + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }
}
