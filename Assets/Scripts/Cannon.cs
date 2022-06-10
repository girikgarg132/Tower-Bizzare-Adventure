using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [HideInInspector] public Waypoint baseWaypoint;

    [SerializeField] float attackRange = 10f;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float timeBetweenShots = 5f;
    [SerializeField] float bulletForce = 5f;

    private Transform targetEnemy;
    private bool canShoot = true;

    void Update()
    {
        SetTargetEnemy();
        if (targetEnemy)
        {
            transform.right = targetEnemy.position - transform.position;
            FireAtEnemy();
        }
    }

    private void SetTargetEnemy()
    {
        EnemyHealth[] enemies = FindObjectsOfType<EnemyHealth>();
        if (enemies.Length == 0) { return; }
        Transform closestEnemy = enemies[0].transform;
        foreach (EnemyHealth testEnemy in enemies)
        {
            closestEnemy = GetClosest(closestEnemy,testEnemy.transform);
        }
        targetEnemy = closestEnemy;
    }

    private Transform GetClosest(Transform transformA, Transform transformB)
    {
        float distToA = Vector3.Distance(transformA.position, transform.position);
        float distToB = Vector3.Distance(transformB.position, transform.position);
        if (distToA < distToB)
        {
            return transformA;
        }
        return transformB;
    }

    private void FireAtEnemy()
    {
        if (Vector3.Distance(transform.position, targetEnemy.transform.position) <= attackRange && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bullet.transform.right * bulletForce, ForceMode2D.Impulse);
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }
}
