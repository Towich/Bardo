using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    private float lifeTime;
    private float distance;
    private int damage;

    // Start is called before the first frame update
    void Start()
    {
        lifeTime = 0.5f;
        distance = 1f;
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("HITTED!");
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
