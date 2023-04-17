using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float speed;
    
    private GameObject player;
    private Transform playerTransform;
    private PlayerController playerController;
    private int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
        
        hp = 100;
        damage = 30;
        speed = 4f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(
            transform.position, 
            playerTransform.position, 
            speed * Time.deltaTime
            );
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.TakeDecreaseStability(damage);
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        // something
    }
}
