using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float hitPoints = 10;

    [SerializeField] AudioClip enemyHitSFX;
    [SerializeField] AudioClip enemyDeathSFX;


    public void ProcessHit(float damage)
    {
        hitPoints -= damage;
        AudioSource.PlayClipAtPoint(enemyHitSFX, Camera.main.transform.position, 0.5f);
    }
    
    public void KillEnemy()
    {
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position, 0.5f);
        Destroy(gameObject);
    }
}
