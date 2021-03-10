using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    /// <summary>
    ///  This script is to put all dialogue and put the method of printing dialogue
    /// </summary>

    // Create a list to put all dialogue, change the texture in main unity window 
    public List<string> dialogues;

    public Text dialogue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to print dialogue, will be used by send message by other dialogue controller script put in pther specific text.
    public void printDialogue(int i)
    {
        dialogue.text = dialogues[i];
    }
}
