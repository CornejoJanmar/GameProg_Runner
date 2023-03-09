using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{

    //NOTICE: THE CODE IS VERY CONFUSING... I havent fully arranged and or optimized the code.

    [SerializeField] float Speed = 2;
    [SerializeField] float LSpeed = 3;
    [SerializeField] float RSpeed = 3;

    [SerializeField] Animator Anim;
    [SerializeField] bool crawling;
    [SerializeField] bool floating;
    [SerializeField] float PlayerHitCount = 0;
    [SerializeField] GameObject balloon;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed, Space.World);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * LSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * RSpeed);
        }

        if (crawling == true)
        {
            if(PlayerHitCount >= 1)
            {
                Anim.SetBool("IsCrawling", true);
            }
            else
            {
                Anim.SetBool("IsCrawling", false);
            }
        }

        if (floating == true)
        {
                Anim.SetBool("IsFloating", true);
        }
    }

    public void CollisionHit()
    {
        //code on losing limbs
        PlayerHitCount += 1;
        
        if (crawling == false)
        {
            if (floating == true)
            {
                balloon.SetActive(false);
                floating = false;
                Anim.SetBool("IsFloating", false);
            }
            crawling = true;
        }
        if(PlayerHitCount == 5)
        {
            Death();
        }
    }

    public void CollectableFloat()
    {
        //code on player float and getting limbs back
        if(PlayerHitCount == 0)
        {
            balloon.SetActive(true);
            floating = true;
        }
        if(PlayerHitCount >= 1)
        {
            PlayerHitCount -= 1;
        }
    }

    public void Death()
    {        
        Speed = 0;
        LSpeed = 0;
        RSpeed = 0;
        this.gameObject.GetComponent<Rigidbody>().useGravity = false;
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Anim.Play("Death");
    }
}
