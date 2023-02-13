using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideReflect : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        bool done = false;
        foreach (ContactPoint contact in collision.contacts)
        {
            if (!done)
            {

                if (contact.otherCollider.name == "Blade")
                {
                    Rigidbody rb = GetComponent(typeof(Rigidbody)) as Rigidbody;
                    Vector3 directionVec = rb.velocity;
                    directionVec.Normalize();
                    float velocity = rb.velocity.magnitude;
                    directionVec = Vector3.Reflect(directionVec, contact.normal);
                    Debug.DrawRay(contact.point, directionVec, Color.white);
                    rb.AddForce(directionVec * 20, ForceMode.VelocityChange);
                    Quaternion direction = Quaternion.identity;
                    direction.SetLookRotation(directionVec, Vector3.up);
                    transform.rotation = direction;
                    print("Blade deflection!");
                }
                else
                {
                    Destroy(gameObject);
                    print("Terrain HIT");
                }
                done = true;
            }

        }
    }
}
