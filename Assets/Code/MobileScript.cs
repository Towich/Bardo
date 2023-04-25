using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileScript : MonoBehaviour
{
   public PlayerController player;
   public GameObject joystick;
   public GameObject buttonE;
   
   public void ChangeToMobile()
   {
      player.mobile = true;
      Destroy(transform.parent.gameObject);
   }

   public void Close()
   {
      Destroy(joystick);
      Destroy(buttonE);
      Destroy(transform.parent.gameObject);
   }
}
