using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("Player Movement")]
    public float speed;
    public LayerMask objLayers;

    [Header("Jump")]
    public float jumpPower;
    
    
    [Header("GroundCheck")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float checkGroundDistance;
    
    private bool isStun;
    private bool isDash = false;
    private Vector2 inputVec;
    private float jumpCnt;
    
    
    public bool IsGround => Physics2D.Raycast(transform.position, Vector2.down, checkGroundDistance, groundLayer);
    
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
    
    void Jump()
    {
        if (!isStun)
        {
                if (Input.GetKeyDown(KeyCode.Space) && jumpCnt < 2)
                {
                    
                    rigid.velocity = Vector2.zero;
                    rigid.AddForce(Vector2.up * jumpPower,ForceMode2D.Impulse);
                    jumpCnt++;
                }
        }
    }
    bool IsFrontObj()
    {
        return Physics2D.Raycast(transform.position, Vector2.right * (transform.localScale.x > 0 ? 1 : -1), 0.5f, objLayers) == true;
    }
    void Update()
    {
        Jump();
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
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name.Equals("Ground"))
        {
            jumpCnt = 0;
        }
    }
}
