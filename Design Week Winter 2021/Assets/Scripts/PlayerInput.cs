using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public const string AXIS_HORIZONTAL = "Horizontal";
    public const string AXIS_VERTICAL = "Vertical";

    public static Vector2 GetDirectionalInput()
    {
        return new Vector2(Input.GetAxisRaw(AXIS_HORIZONTAL), Input.GetAxisRaw(AXIS_VERTICAL));
    }
}
