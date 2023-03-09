using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] PlayerMovement Pm;

    private void OnCollisionEnter(Collision collision)
    {
        Pm.GetComponent<PlayerMovement>().CollisionHit();
    }
}
