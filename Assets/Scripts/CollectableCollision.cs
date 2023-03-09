using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCollision : MonoBehaviour
{

    public GameObject Player;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //code on giving limbs and making player float
            Player.GetComponent<PlayerMovement>().CollectableFloat();
            this.gameObject.SetActive(false);
        }
        
    }
}
