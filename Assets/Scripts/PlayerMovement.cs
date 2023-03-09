using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float Speed = 2;
    [SerializeField] float LSpeed = 3;
    [SerializeField] float RSpeed = 3;

    [SerializeField] Animator Anim;
    [SerializeField] bool IsCrawling;
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

        if (IsCrawling == true)
        {
            Anim.SetBool("IsCrawling", true);
        }
    }

    public void CollisionHit()
    {
        IsCrawling = true;

    }
}
