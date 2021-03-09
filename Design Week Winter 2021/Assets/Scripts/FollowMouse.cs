using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    new Vector3 position;
    [SerializeField] Transform player;
    [SerializeField] Transform reticle;//used to contain reticle


    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 worldSpacePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);// move to mouse according to world space(game screen)

        worldSpacePosition.z += Camera.main.nearClipPlane;//camera plane more than worlspaceposition z so we can see our crosshair

        reticle.transform.position = new Vector3(worldSpacePosition.x,worldSpacePosition.y,0);// make the reticle equal to worldspace position


        



    }

    
    
    void onTriggerEnter2D(Collider2D col) {


        Debug.Log("this is"+col.gameObject);
    
    
    }
}
