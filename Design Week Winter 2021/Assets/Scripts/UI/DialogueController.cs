using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    /// <summary>
    ///  will be used in text object
    /// </summary>

    GameObject canvas;
    public GameObject Text;
    public GameObject TextBox;

    // number is which dialogue is now appearing
    // limit is the number of all this part dialogue
    public int number = 0;
    public int limit = 5;
    
    // a boolean to check if the game start 
    public bool dialogueAppear = true;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && number > 0)
        {
            dialogueAppear = true;
            number -= 1;
        }
        if (dialogueAppear)
        {
            // If we need dialogue, make it appear first
            Text.SetActive(true);
            TextBox.SetActive(true);
            // use method in dialogue to find texture and print it
            canvas.SendMessage("printDialogue", number);
            // if mouse left button click, go to the next dialogue
            if (Input.GetMouseButtonDown(0))
            {
                number += 1;
            }
            // if this part is finished, make it disappear
            if (number == limit)
            {
                dialogueAppear = false;
                Text.SetActive(false);
                TextBox.SetActive(false);
            }
        }
    }
}
