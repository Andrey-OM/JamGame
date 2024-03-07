using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public float speed = 5f;
    public bool runNorth;
    public bool runSouth;
    public bool runLeft;
    public bool runRight;

    public Animator animator;

    public LayerMask whatIsSolid;

    void Update()
    {
        //var hit = Physics2D.Raycast(transform.position, transform.right, 0, whatIsSolid).collider;


        animator.SetBool("runNorth", runNorth); //Сделать фиксед адпейт
        animator.SetBool("runSouth", runSouth);
        animator.SetBool("runRight", runRight);
        animator.SetBool("runLeft", runLeft);

        if (Input.GetKey(KeyCode.LeftShift)) speed = 10f;
        else speed = 5f;

        Vector2 dir = Vector2.zero;

        

        

        if (Input.anyKey) // && 
        {
            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                //transform.Translate(new Vector2(0, 1) * speed * Time.deltaTime);
                runNorth = true;
            }
            else runNorth = false;
            if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                //transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);
                runRight = true;
            }
            else runRight = false;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                //transform.Translate(new Vector2(-1, 0) * speed * Time.deltaTime);
                runLeft = true;
            }
            else runLeft = false;
            if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                //transform.Translate(new Vector2(0, -1) * speed * Time.deltaTime);
                runSouth = true;
            }
            else runSouth = false;
        }
        else
        {
            runNorth = false;
            runRight = false;
            runLeft = false;
            runSouth = false;
        }

        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }
}
