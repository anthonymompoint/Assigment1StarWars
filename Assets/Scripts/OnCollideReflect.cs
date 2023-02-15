using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollideReflect : MonoBehaviour
{
    public GameObject explosionSystem;
    public GameObject burstSystem;
    public GameObject explosionSound;
    public GameObject deflectSound;
    void OnCollisionEnter(Collision collision)
    {
        bool done = false;
        bool bladeContact = false;
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
                    Instantiate(burstSystem, contact.point, Quaternion.identity);
                    Instantiate(deflectSound, contact.point, Quaternion.identity);
                    transform.rotation = direction;
                    bladeContact = true;
                    //print("Blade deflection!");
                    done = true;
                    break;
                }
                else if (contact.otherCollider.name == "Player" && bladeContact) { break; ; }
                else
                {
                    if ((contact.otherCollider.name == "Player" && !bladeContact))
                    { 
                        PlayerInfoControl pic = contact.otherCollider.GetComponentInParent<PlayerInfoControl>();
                        pic.playerHit(10);
                    }
                    Destroy(gameObject);
                    Instantiate(explosionSystem, transform.position, Quaternion.identity);
                    Instantiate(explosionSound, contact.point, Quaternion.identity);
                    //print("Terrain HIT");
                }
                done = true;
            }

        }
    }
}
