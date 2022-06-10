using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    [SerializeField] Text levelText;

    void Start()
    {
        levelText.text = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }
}
