using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_RoomFlipper : MonoBehaviour
{
    public Transform teleportLocation;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (other.gameObject.tag == "Player")
            {

                RT_MoveBasic.instance.transform.position = teleportLocation.position;
            }
        }
    }
}
