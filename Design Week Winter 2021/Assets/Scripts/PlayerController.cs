using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance = null;
    public enum FacingDirection { Left, Right }

    private Vector2 input;
    private Vector2 lastmovement;

    [SerializeField]
    private float m_accelerationTimeFromRest;

    [SerializeField]
    private float m_decelerationTimeToRest;

    [SerializeField]
    private float m_maxHorizontalSpeed;

    private Rigidbody2D rb;

    public Vector3 velocity;
    private FacingDirection lastdir;

    public bool IsWalking()
    {
        if (NewBehaviourScript.GetDirectionalInput().x != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public FacingDirection GetFacingDirection()
    {
        if (input.x > 0)
        {
            lastdir = FacingDirection.Right;
            return FacingDirection.Right;
        }
        else if (input.x < 0)
        {
            lastdir = FacingDirection.Left;
            return FacingDirection.Left;
        }
        return lastdir;
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

        // Start is called before the first frame update
        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float acceleration = m_maxHorizontalSpeed / m_accelerationTimeFromRest;
        float deceleration = m_maxHorizontalSpeed / m_decelerationTimeToRest;

        

        input = NewBehaviourScript.GetDirectionalInput();

        if (IsWalking())
        {
            velocity.x += ((m_maxHorizontalSpeed / m_accelerationTimeFromRest) * Time.deltaTime);
            lastmovement.x = input.x;
        }
        else
        {
            velocity.x -= ((m_maxHorizontalSpeed / m_decelerationTimeToRest) * Time.deltaTime);
            input.x = lastmovement.x;
        }

        velocity.x = Mathf.Clamp(velocity.x, 0, m_maxHorizontalSpeed);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocity.x * input.x, (velocity.y));
    }


}