using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health = 10;
    [SerializeField] Slider healthBar;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject gameSceneUI;

    private void Start()
    {
        healthBar.minValue = 0;
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    public void OnDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        gameSceneUI.SetActive(false);
    }

}
