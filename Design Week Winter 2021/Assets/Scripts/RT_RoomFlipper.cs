using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_RoomFlipper : MonoBehaviour
{
    public Transform teleportLocation;
    public bool doorLocked = false;

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
                //DialogueController.instance.TextSegmentTwo();
            }
            else if(other.gameObject.tag == "Player" && this.gameObject.tag == "Basement" && PlayerController.instance.holdingFlashlight)
            {
                doorLocked = false;
            }

            if(other.gameObject.tag == "Player" && this.gameObject.tag == "Basement" && !doorLocked)
            {
                PlayerController.instance.transform.position = teleportLocation.position;

            }
        }
    }

    private void Awake()
    {
        if(gameObject.tag == "Basement")
        {
            doorLocked = true;
        }
    }
}
