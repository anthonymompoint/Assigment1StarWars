using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedLife : MonoBehaviour
{
    public float lifeTime = 5;
    private float spawnTime;

    void Start()
    {
        spawnTime = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if((lifeTime + spawnTime) - Time.time < 0)
        {
            Destroy(gameObject);
        }
    }
}
