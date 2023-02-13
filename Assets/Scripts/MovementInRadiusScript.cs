using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementInRadiusScript : MonoBehaviour
{
    public GameObject target;
    public float rangeInner;
    public float rangeOuter;
    public float verticalRangeDegrees;
    public Vector3 targetPoint;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
 
        targetPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Vector3.Magnitude(transform.position - targetPoint)) <= .1)
        {
            float polar = Random.Range(Mathf.Deg2Rad * (90- verticalRangeDegrees), Mathf.Deg2Rad *  (90));
            float alpha  = Random.Range(0, 360 * Mathf.Deg2Rad);
            float r = Random.Range(rangeInner, rangeOuter);

            targetPoint = new Vector3(0,0,0);
            targetPoint.x = r * Mathf.Sin(polar) * Mathf.Cos(alpha) + target.transform.position.x;
            targetPoint.z = r * Mathf.Sin(polar) * Mathf.Sin(alpha) + target.transform.position.z;
            targetPoint.y = r * Mathf.Cos(polar) + target.transform.position.y;

            SpawnLaserTowardsObj SLTO = GetComponent(typeof(SpawnLaserTowardsObj)) as SpawnLaserTowardsObj;
            SLTO.fireLaser();
        }
        else
        {
            Vector3 direction = targetPoint - transform.position;
            transform.position += direction * speed * Time.deltaTime;
        }
    }
}
