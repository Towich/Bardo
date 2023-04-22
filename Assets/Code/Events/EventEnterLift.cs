using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnterLift : MonoBehaviour
{
    [SerializeField] private bool goingToHospital;
    public Animator BlackBackgroundAnimator;
    public Animator coolBackground;
    
    private Vector3 posMiddle;
    private Vector3 posHospital;
    
    public PlayerController player;
    private Transform playerTransform;
    public Animator liftAnimator;
    public Animator lift2Animator;
    public Transform cameraTransform;

    public GameObject stabilityUI;
    public GameObject inventoryUI;
    
    public SpriteRenderer liftDoorSpriteRenderer;
    private int startSortingOrder;

    private float distanceMain_Middle = 20f;

    private void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        startSortingOrder = liftDoorSpriteRenderer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            StartCoroutine(StartLiftEvent());
        }
    }

    private IEnumerator StartLiftEvent()
    {
        // #1 Closing lift
        liftAnimator.Play("LiftClose");
        BlackBackgroundAnimator.Play("BlackBackgroundOn");
        liftDoorSpriteRenderer.sortingOrder = 2;
        
        yield return new WaitForSeconds(5f);
        
        // #2 Teleport to Middle Lift
        stabilityUI.SetActive(false);
        inventoryUI.SetActive(false);

        posMiddle = new Vector3(playerTransform.position.x, playerTransform.position.y - distanceMain_Middle, playerTransform.position.z);
        
        playerTransform.position = posMiddle;
        cameraTransform.position = posMiddle;

        yield return new WaitForSeconds(1f);
        
        // #3 Showing CoolBackground
        BlackBackgroundAnimator.Play("BlackBackgroundOff");
        coolBackground.Play("CoolBackgroundUp");
        
        yield return new WaitForSeconds(10f);
        
        // #4 Showing BlackBackground
        BlackBackgroundAnimator.Play("BlackBackgroundOn");
        yield return new WaitForSeconds(3f);
        
        // #5 Teleport to Hospital + Turning off BlackBackground
        posHospital = new Vector3(playerTransform.position.x, playerTransform.position.y - 2*distanceMain_Middle, playerTransform.position.z);
        playerTransform.position = posHospital;
        cameraTransform.position = posHospital;
        BlackBackgroundAnimator.Play("BlackBackgroundOff");
        liftDoorSpriteRenderer.sortingOrder = startSortingOrder;
        stabilityUI.SetActive(true);
        inventoryUI.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        
        // #6 Open lift2 door
        lift2Animator.Play("LiftOpen");
        
        yield return null;
    }
}
