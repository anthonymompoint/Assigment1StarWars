using UnityEngine;

public class CycleCube : MonoBehaviour
{
    //Assign a GameObject in the Inspector to rotate around
    public GameObject target;

    // Start is called before the first frame update
    private void Start()
    {
    }

    private void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(target.transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        print($"{gameObject.name} hit {other.name}");

        if (other.name == "Blade")
            Destroy(gameObject);

    }
}