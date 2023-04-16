using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float offsetDirection;
    
    private GameObject player;
    private Vector3 posShot;
    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
        offsetDirection = 0.31f;
    }

    // Update is called once per frame
    void Update()
    {
        // Shot
        if (Input.GetMouseButtonDown(0))
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");

            posShot = new Vector3(transform.position.x + offsetDirection + direction.x * offsetDirection, 
                transform.position.y + direction.y * offsetDirection*2, transform.position.z);
            
            GameObject newBullet = Instantiate(bullet, posShot, transform.rotation);
        }
    }
}
