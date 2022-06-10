using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletDamage = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            enemy.ProcessHit(bulletDamage);
            if (enemy.hitPoints <= 0)
            {
                enemy.KillEnemy();
            }
        }
        Destroy(gameObject);
    }
}
