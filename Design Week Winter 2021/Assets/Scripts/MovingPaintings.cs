using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPaintings : MonoBehaviour
{
    [SerializeField] Transform moveSpot;
    [SerializeField] int targetTasksCompleted;
    [SerializeField] float distanceFromPlayer;
    bool paintingMoved;

    private void Update()
    {
        if(GameManager.instance.playerTasksCompleted >= targetTasksCompleted && !paintingMoved)
        {
            MovePainting();
        }
    }

    void MovePainting()
    {
        if(Vector2.Distance(transform.position, PlayerController.instance.transform.position) > distanceFromPlayer)
        {
            transform.position = moveSpot.position;
            paintingMoved = true;
        }
    }

}
