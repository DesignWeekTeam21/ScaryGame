using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checklist : MonoBehaviour
{
    public float movementSpeed = 5f;

    private bool checklistUp = false;

    public static bool canPress = true;

    public Image goToSleep;
    public Image check1;
    public Image check2;
    public Image check3;

    private void Start()
    {
        goToSleep.enabled = false;
        check1.enabled = false;
        check2.enabled = false;
        check3.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        print(canPress);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (checklistUp == false && canPress == true)
            {               
                MoveObjectTo(this.transform, new Vector3(this.transform.position.x, this.transform.position.y + 174, this.transform.position.z), movementSpeed);
                checklistUp = true;
            }

            else if (checklistUp == true && canPress == true)
            {
                MoveObjectTo(this.transform, new Vector3(this.transform.position.x, this.transform.position.y - 174, this.transform.position.z), movementSpeed);
                checklistUp = false;
            }
            /*
             * If you want to move it every time by -12 (new Vector3(this.transform.position.x -12, this.transform.position.y, this.transform.position.z)), 
             * or by some other value and axis - just change 
             * the targetPosition Vector3 passed in the argument of MoveObjectTo(); 
             */
        }
}

    private void MoveObjectTo(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        //StopCoroutine(MoveObject(objectToMove, targetPosition, moveSpeed));
        if (canPress == true)
        {
            StartCoroutine(MoveObject(objectToMove, targetPosition, moveSpeed));
        }
    }

    public static IEnumerator MoveObject(Transform objectToMove, Vector3 targetPosition, float moveSpeed)
    {
        canPress = false;
        float currentProgress = 0;
        Vector3 cashedObjectPosition = objectToMove.transform.position;

        while (currentProgress <= 1)
        {
            currentProgress += moveSpeed * Time.deltaTime;

            objectToMove.position = Vector3.Lerp(cashedObjectPosition, targetPosition, currentProgress);

            yield return null;
        }
        canPress = true;
    }
}
