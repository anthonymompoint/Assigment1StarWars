using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float lastSpawnedTime = 0;

    private void Update()
    {
        print(Time.time);
        if (Time.time - lastSpawnedTime > 1)
        {
            lastSpawnedTime = Time.time;
            Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10)), Quaternion.identity);
        }
    }
}