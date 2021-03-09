using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance = null;
    private SpriteRenderer spriteRenderer;
    private Animator m_animator;
    private Rigidbody2D rb;

    public enum FacingDirection { Left, Right }

    private Vector2 input;
    private Vector2 lastmovement;

    [SerializeField] private float m_accelerationTimeFromRest;
    [SerializeField] private float m_decelerationTimeToRest;
    [SerializeField] private float m_maxHorizontalSpeed;

    public Vector3 velocity;
    private FacingDirection lastdir;

    private int IsWalkingProperty;
    private int IsGrabbingProperty;

    public GameObject heldObject;
    private bool isGrabbingObject;

    public float footstepDelay;
    private float footstepTimer;
   

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

    public bool IsGrabbing()
    {
        if (Input.GetKey(KeyCode.E))
        {
            return true;
            
        }

        return false;
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

        m_animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        IsWalkingProperty = Animator.StringToHash("isWalking");
        IsGrabbingProperty = Animator.StringToHash("isGrabbing");
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector2(0, 0);
    }

    void Update()
    {
        HandleAnimations();
        HandleMovement();

        if (isGrabbingObject)
        {
            GrabObject();
        }

        if (IsWalking())
        {
            if (footstepTimer < footstepDelay)
            {
                footstepTimer += Time.deltaTime;
                Debug.Log(footstepTimer);
            }
            else
            {
                GameManager.instance.PlayFootStep();
                footstepTimer = 0;
            }
        }
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocity.x * input.x, (velocity.y));
    }

    void GrabObject()
    {
        switch (GetFacingDirection())
        {
            case FacingDirection.Left:
                heldObject.transform.position = transform.position + (transform.right * -0.7f);
                break;
            case FacingDirection.Right:
                heldObject.transform.position = transform.position + (transform.right * 0.7f);

                break;
        }
    }

    void HandleAnimations()
    {
        switch (GetFacingDirection())
        {
            case FacingDirection.Left:
                spriteRenderer.flipX = true;
                if (heldObject)
                {
                    heldObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                break;
            case FacingDirection.Right:
                spriteRenderer.flipX = false;
                if (heldObject)
                {
                    heldObject.GetComponent<SpriteRenderer>().flipX = false;
                }
                break;
            default:
                break;
        }

        m_animator.SetBool(IsWalkingProperty, IsWalking());
        m_animator.SetBool(IsGrabbingProperty, IsGrabbing());
    }

    void HandleMovement()
    {
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Can" && IsGrabbing())
        {
            isGrabbingObject = true;
            heldObject = collision.gameObject;
        }

        if(collision.tag == "Plant" && heldObject && IsGrabbing())
        {
            heldObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}