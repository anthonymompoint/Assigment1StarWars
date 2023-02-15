using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaserTowardsObj : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject target;
    public float spawnTimer;
    private float lastSpawnedTime = 0;
    public float velocity = 1;
    public GameObject sfxef;

    // Update is called once per frame
    void Update()
    {
        if((spawnTimer != -1) && (Time.time - lastSpawnedTime > spawnTimer))
        {
            lastSpawnedTime = Time.time;
            fireLaser();
        }
    }

    public void fireLaser()
    {
        Quaternion direction = Quaternion.identity;
        Quaternion offset = transform.rotation;
        direction.SetLookRotation(target.transform.position - transform.position, Vector3.up);
        Vector3 directionVec = (target.transform.position - transform.position);
        directionVec.Normalize();
        GameObject enemy = Instantiate(enemyPrefab, transform.position + directionVec * .1f, direction * transform.rotation) as GameObject;
        Instantiate(sfxef, transform.position + directionVec * .1f, direction * transform.rotation);
        Rigidbody rb = enemy.GetComponent(typeof(Rigidbody)) as Rigidbody;
        rb.AddForce(directionVec * velocity, ForceMode.VelocityChange);
    }
}
