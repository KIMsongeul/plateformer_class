using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed;
    public float dashPower;
    public LayerMask objLayers;

    [Header("Jump")]
    public float jumpPower;


    private bool isStun;
    private bool isDash;
    
    private Vector2 inputVec;
    // Components
    private Animator ani;
    private Rigidbody2D rigid;

    void Move()
    {
        if (!isStun)
        {
            if (!isDash)
            {
                
                Vector2 nextVec = inputVec.normalized * (speed);
                rigid.velocity = !IsFrontObj() ? new Vector2(nextVec.x, rigid.velocity.y) : new Vector2(0, rigid.velocity.y);
            }



            if (!isDash)
            {
                if (inputVec.x > 0)
                {
                    transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
                }
                else if (inputVec.x < 0)
                {
                    transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }
    bool IsFrontObj()
    {
        return Physics2D.Raycast(transform.position, Vector2.right * (transform.localScale.x > 0 ? 1 : -1), 0.5f, objLayers) == true;
    }
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        Move();
    }

    void Start()
    {
        ani = GetComponentInChildren<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }
}
