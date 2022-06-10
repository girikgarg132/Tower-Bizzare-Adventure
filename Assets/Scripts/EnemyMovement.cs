using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] AudioClip enemyExplodeSFX;
    [SerializeField] float enemyDamage = 1;

    private PlayerHealth playerHealth;
    private Transform path;

    void Start()
    {
        path = GameObject.FindGameObjectWithTag("Path").transform;
        playerHealth = GameObject.FindGameObjectWithTag("GameManager").GetComponent<PlayerHealth>();
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Transform waypoint in path)
        {
            if (waypoint.CompareTag("CurvePath"))
            {
                while (transform.position != waypoint.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, waypoint.position, movementSpeed * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                }
            }
            if (waypoint.CompareTag("EndPath"))
            {
                while (transform.position != waypoint.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, waypoint.position, movementSpeed * Time.deltaTime);
                    yield return new WaitForEndOfFrame();
                }
            }
        }
        SelfDestructor();
    }

    private void SelfDestructor()
    {
        playerHealth.OnDamage(enemyDamage);
        AudioSource.PlayClipAtPoint(enemyExplodeSFX, Camera.main.transform.position, 0.5f);
        Destroy(gameObject);
    }
}
