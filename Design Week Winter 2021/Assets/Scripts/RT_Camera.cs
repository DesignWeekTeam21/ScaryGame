using UnityEngine;
using System.Collections;

public class RT_Camera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;

    [SerializeField] Vector2 minimumBoundary = Vector2.zero;
    [SerializeField] Vector2 maximumBoundary = Vector2.zero;

    private void Update()
    {
        //ClampCameraBounds();
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }

    void ClampCameraBounds()
    {
        //Clamp boundaries
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minimumBoundary.x, maximumBoundary.x),
            Mathf.Clamp(transform.position.y, minimumBoundary.y, maximumBoundary.y), transform.position.z);
    }
}
