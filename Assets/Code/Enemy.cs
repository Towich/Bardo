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
    
    private Animator animator;
    private Vector2 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();
        playerController = player.GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        
        hp = 100;
        damage = 5;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        direction = (playerTransform.position - transform.position).normalized;
        
        // Setting the variables in Animator
        // used for playing animation of walk in right direction
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
        
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
            playerController.TakeDecreaseStability(damage, 0.2f, 0.3f);
            StartDestroyEnemy();
        }
    }

    private void OnMouseDown()
    {
        StartDestroyEnemy();
    }

    private void StartDestroyEnemy()
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
        sr.color = Color.green;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
        yield return null;
    }
}
