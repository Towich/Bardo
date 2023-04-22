using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryMomentEvent : MonoBehaviour
{
    public Animator cameraAnim;

    public Animator scaryMomentAnim;

    public PlayerController playerController;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            cameraAnim.enabled = true;
            scaryMomentAnim.enabled = true;
            
            playerController.TurnMovement(false);
            playerController.enabled = false;
            
            
            cameraAnim.Play("ScaryMomentCamera");
            scaryMomentAnim.Play("ScaryMoment");
            Destroy(gameObject);
        }
    }
}
