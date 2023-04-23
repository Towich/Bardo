using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventEnterLift : MonoBehaviour
{
    [SerializeField] private bool goingToMain;
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
    public SpriteRenderer lift2DoorSpriteRenderer;
    private int startSortingOrder;
    private int start2SortingOrder;

    private float distanceMain_Middle = 20f;
    public GameObject stabilizator;

    private void Start()
    {
        playerTransform = player.GetComponent<Transform>();
        startSortingOrder = liftDoorSpriteRenderer.sortingOrder;
        start2SortingOrder = lift2DoorSpriteRenderer.sortingOrder;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (goingToMain && !stabilizator)
            {
                StartCoroutine(StartLiftEvent());
            }
            else if (!goingToMain && stabilizator)
            {
                StartCoroutine(StartLiftEvent());
            }
        }
    }

    private IEnumerator StartLiftEvent()
    {
        // #1 Closing lift
        liftAnimator.Play("LiftClose");
        BlackBackgroundAnimator.Play("BlackBackgroundOn");
        liftDoorSpriteRenderer.sortingOrder = 2;
        lift2DoorSpriteRenderer.sortingOrder = 2;
        
        yield return new WaitForSeconds(5f);
        
        // #2 Teleport to Middle Lift
        stabilityUI.SetActive(false);
        inventoryUI.SetActive(false);

        float localDistance = goingToMain ? -2f * distanceMain_Middle : distanceMain_Middle;
        
        posMiddle = new Vector3(playerTransform.position.x, playerTransform.position.y - localDistance, playerTransform.position.z);
        
        playerTransform.position = posMiddle;
        cameraTransform.position = posMiddle;

        yield return new WaitForSeconds(1f);
        
        // #3 Showing CoolBackground
        BlackBackgroundAnimator.Play("BlackBackgroundOff");

        coolBackground.Play(!goingToMain ? "CoolBackgroundUp" : "CoolBackgroundDown");

        yield return new WaitForSeconds(10f);
        
        // #4 Showing BlackBackground
        BlackBackgroundAnimator.Play("BlackBackgroundOn");
        lift2DoorSpriteRenderer.sortingOrder = 2;
        
        yield return new WaitForSeconds(3f);
        
        // #5 Teleport to Hospital + Turning off BlackBackground

        localDistance = goingToMain ? -1f * distanceMain_Middle : 2f * distanceMain_Middle;
        posHospital = new Vector3(playerTransform.position.x, playerTransform.position.y - localDistance, playerTransform.position.z);
        playerTransform.position = posHospital;
        cameraTransform.position = posHospital;
        BlackBackgroundAnimator.Play("BlackBackgroundOff");
        
        stabilityUI.SetActive(true);
        inventoryUI.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        
        liftDoorSpriteRenderer.sortingOrder = startSortingOrder;
        
        if(goingToMain)
            lift2DoorSpriteRenderer.sortingOrder = 29;
        else
        {
            lift2DoorSpriteRenderer.sortingOrder = 90;
        }
        
        // #6 Open lift2 door
        lift2Animator.Play("LiftOpen");
        
        yield return null;
    }
}
