using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f,120f)][SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement[] enemyPrefabs;
    [SerializeField] Text[] scoreText;
    [SerializeField] int scoreIncrement = 1;
    int score = 0;

    private void Start()
    {
        foreach (Text text in scoreText)
        {
            text.text = "Score = " + score.ToString();
        }
        StartCoroutine(SpawnEnemy());
    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform);
                AddScore();
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        foreach (Text text in scoreText)
        {
            text.text = "Score = " + score.ToString();
        }
        score += scoreIncrement;
    }
}
