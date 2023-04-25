using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public Text stabilityText;
    public float speed;
    public CameraShake cameraShake;
    public PostGlitchEffect glitchEffect;
    public GameObject deathScreen;
    public FixedJoystick _joystick;
    public bool mobile;
    
    private GameManager gameManager;
    private Animator animator;
    private Vector2 direction;
    private Rigidbody2D rb;
    private int stability;

    private AudioSource audioSource;

    private bool enabledMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }
    
    private void InitVariables()
    {
        enabledMovement = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        stability = 100;

        enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (mobile)
        {
            direction.x = _joystick.Horizontal;
            direction.y = _joystick.Vertical;
        }

        // Setting the variables in Animator
        // used for playing animation of walk in right direction
        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }
    
    private void FixedUpdate()
    {
        // moving player Up/Down/Left/Right
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    public void TakeDecreaseStability(int delta, float duration, float magnitude)
    {
        // 0.2f + 0.3f
        StopAllCoroutines();
        stability -= delta;

        if (stability > 100)
            stability = 100;
        
        gameManager.UpdateStability(stability);
        stabilityText.text = stability.ToString();
        StartCoroutine(cameraShake.Shake(duration, magnitude));
        StartCoroutine(glitchEffect.SmoothTransition());

        if (stability <= 0)
            ShowDeathScreen();
    }

    public void TurnMovement(bool toEnable)
    {
        if (toEnable)
        {
            animator.enabled = toEnable;
            animator.Play("Idle");
        }
        else
        {
            animator.Play("Idle");
            animator.enabled = toEnable;
        }
    }

    private void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
    }
}
