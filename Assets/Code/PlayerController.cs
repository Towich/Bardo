using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }
    
    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        
        // Setting the variables in Animator
        // used for playing animation of walk in right direction
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    private void InitVariables()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // moving player Up/Down/Left/Right
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime); 
    }
}
