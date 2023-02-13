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
        GameObject enemy = Instantiate(enemyPrefab, transform.position, direction * transform.rotation) as GameObject;
        Rigidbody rb = enemy.GetComponent(typeof(Rigidbody)) as Rigidbody;
        Vector3 directionVec = (target.transform.position - transform.position);
        directionVec.Normalize();
        rb.AddForce(directionVec * velocity, ForceMode.VelocityChange);
    }
}
