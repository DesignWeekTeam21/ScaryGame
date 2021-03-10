using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_SmoothRoom : MonoBehaviour
{
    public Transform teleportLocation;

    private void OnTriggerStay2D(Collider2D other)
    {
            if (other.gameObject.tag == "Player")
            {

                PlayerController.instance.transform.position = teleportLocation.position;
            }
    }
}
