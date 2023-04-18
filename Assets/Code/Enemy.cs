using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp;
    public float speed;

    public GameObject effectDeath;

    private SpriteRenderer sr;
    private GameObject player;
    private Transform playerTransform;
    private PlayerController playerController;
    private int damage;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
        
        hp = 100;
        damage = 30;
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

    private void OnMouseDown()
    {
        Instantiate(effectDeath, transform.position, Quaternion.identity);
        StartCoroutine(DestroyEnemy());
    }

    public void TakeDamage()
    {
        // something
    }

    private IEnumerator DestroyEnemy()
    {
        //GetComponent<CapsuleCollider2D>().enabled = false;
        //sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        yield return null;
    }
}
