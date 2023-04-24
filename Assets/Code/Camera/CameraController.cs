using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController playerController;
    public Transform playerPos;
    public GameObject enemy;

    private Vector3 posEnd, posSmooth;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SmoothMoveForPlayer();

        if (Input.GetKey(KeyCode.K))
        {
            Vector3 posToSpawn = new Vector3(playerPos.position.x, playerPos.position.y + 10f, playerPos.position.z);
            Instantiate(enemy, posToSpawn, Quaternion.identity);
        }
    }

    private void SmoothMoveForPlayer()
    {
        posEnd = new Vector3(playerPos.position.x, playerPos.position.y, -10f);

        posSmooth = Vector3.Lerp(transform.position, posEnd, 0.125f);
        
        transform.position = posSmooth;
    }
    
    public void StopScaryCamera()
    {
        GetComponent<Animator>().enabled = false;

        playerController.TakeDecreaseStability(0, .1f, 0.1f);
        ShowDialogue();
        
        
        gameManager.ScaryMomentSpawnEnemy();
    }

    private void ShowDialogue()
    {
        gameManager.StartCoroutine(gameManager.ShowScaryMomentUI());
    }
}
