using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RT_MoveBasic : MonoBehaviour
{
    public float speed;
    public static RT_MoveBasic instance = null;


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
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = 0;

        gameObject.transform.position = new Vector2(transform.position.x + (h * speed),
           transform.position.y + (v * speed));
    }
}
