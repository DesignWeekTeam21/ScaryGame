using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_RoomFlipper : MonoBehaviour
{
    public Transform teleportLocation;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.tag == "Player" && this.gameObject.tag != "Basement")
            {
                PlayerController.instance.transform.position = teleportLocation.position;
            }

            if(other.gameObject.tag == "Player" && this.gameObject.tag == "Basement" && !PlayerController.instance.holdingFlashlight)
            {
                //trigger dialogue here
            }
            else if(other.gameObject.tag == "Player" && this.gameObject.tag == "Basement" && PlayerController.instance.holdingFlashlight)
            {
                PlayerController.instance.transform.position = teleportLocation.position;

            }
        }
    }
}
