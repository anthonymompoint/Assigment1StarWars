using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPlayer : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {
        print(other.name);
        if (other.name.Contains("Player"))
        {
            PlayerInfoControl pic = other.GetComponentInParent<PlayerInfoControl>();
            if (pic.useForceEnergy(5) && pic.healPlayer(0))
            {
                pic.healPlayer(1);
            }
        }
    }
}
