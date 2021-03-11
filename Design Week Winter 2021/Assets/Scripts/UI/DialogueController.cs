using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    /// <summary>
    ///  will be used in text object
    /// </summary>
    /// 
    public static DialogueController instance = null;

    GameObject canvas;
    public GameObject Text;
    public GameObject TextBox;

    // number is which dialogue is now appearing
    // limit is the number of all this part dialogue
    public int number = 0;
    public int limit = 5;
    public int firstLimit = 5;
    
    // a boolean to check if the game start 
    public bool dialogueAppear = true;
    public bool dialogueTwo = false;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }

    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

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
           

           

        }

        // if this part is finished, make it disappear
        if (number == firstLimit)
        {
            dialogueAppear = false;
            Text.SetActive(false);
            TextBox.SetActive(false);
            number++;
        }

        //This segment is purely to trigger the Dialogue.
        //In other words, this is not needed when a real prompt is put in place.
        if (Input.GetKeyDown(KeyCode.P))
        {
            TextSegmentTwo();
        }

        // second dialogue phase
        if (dialogueTwo == true)
        {
            dialogueAppear = true;
            Text.SetActive(true);
            TextBox.SetActive(true);
        }

        //end display of dialogue
        if (number == limit)
        {
            dialogueAppear = false;
            Text.SetActive(false);
            TextBox.SetActive(false);
        }
    }

    public void TextSegmentTwo()
    {
        number = 6;
        dialogueTwo = true;
        dialogueAppear = true;
        Text.SetActive(true);
        TextBox.SetActive(true);
    }
}
