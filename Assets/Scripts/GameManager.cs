using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Tooltip("in sec")][SerializeField] int timeForLevel = 60;
    [SerializeField] Text timeText;
    [SerializeField] GameObject levelCompleteUI;
    [SerializeField] GameObject gameSceneUI;

    void Start()
    {
        StartCoroutine(TimeCalculation());
    }

    IEnumerator TimeCalculation()
    {
        while (timeForLevel > 0)
        {
            DisplayTime();
            yield return new WaitForSeconds(1);
            timeForLevel--;
        }
        LevelComplete();
    }

    void DisplayTime()
    {
        timeText.text = "Time = " + timeForLevel / 60 + " : " + timeForLevel % 60;
    }

    void LevelComplete()
    {
        Time.timeScale = 0f;
        levelCompleteUI.SetActive(true);
        gameSceneUI.SetActive(false);
    }

}
