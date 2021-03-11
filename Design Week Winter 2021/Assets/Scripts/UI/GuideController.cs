using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// this script is used to control the guide UI, it will import method from guide script
/// </summary>

public class GuideController : MonoBehaviour
{
    GameObject canvas;
    public GameObject Text;
    public GameObject Dialogue;
    public GameObject TextBox;

    public Image A;
    public Image D;
    public Image E;

    // a float for count time
    private float t;
    // floats record transparency
    private float a = 1;
    private float d = 1;
    private float e = 1;

    // a bool to check if guide appear
    private bool guideAppear = false;
    private bool showedA = false;
    private bool showedD = false;
    private bool showedE = false;
    // bools check character touch the items
    public bool interact = false;


    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        UIShowing(); 
        UIDisappear();
    }

    // show guide UI when trigger is on
    void UIShowing()
    {
        if (Dialogue.activeSelf == false)
        {
            // wait 2 second to show the guide
            t += Time.deltaTime;
            if (t > 1 && t < 2)
            {
                if (showedA == false || showedD == false)
                {
                    A.gameObject.SetActive(true);
                    D.gameObject.SetActive(true);
                    Text.SetActive(true);
                    TextBox.SetActive(true);
                    canvas.SendMessage("printGuide", 1);
                }
            }

            if(showedA == true && showedD == true && t > 5)
            {
                if (showedE == false)
                {
                    E.gameObject.SetActive(true);
                    Text.SetActive(true);
                    TextBox.SetActive(true);
                    canvas.SendMessage("printGuide", 2);
                }
            }

            // show guide E when touch the interact items, but just once
            if (interact == true)
            {
                
            }
        }
    }

    void CheckEvent()
    {
        if (t > 2)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                showedA = true;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                showedD = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                showedE = true;
            }
        }
    }

    void UIDisappear()
    {
        CheckEvent();
        if(interact == false)
        {
            // when player pressed the button, the UI become disappear
            if (showedA == true)
            {
                A.gameObject.transform.Translate(0, 15 * Time.deltaTime, 0);
                A.color = new Color(A.color.r, A.color.g, A.color.b, a);
                a -= 2 * Time.deltaTime;
                if (a < 0)
                {
                    A.gameObject.SetActive(false);
                }
            }
            if (showedD == true)
            {
                D.gameObject.transform.Translate(0, 15 * Time.deltaTime, 0);
                D.color = new Color(A.color.r, A.color.g, A.color.b, d);
                d -= 2 * Time.deltaTime;
                if (d < 0)
                {
                    D.gameObject.SetActive(false);
                }
            }
            if (a < 0 && d < 0)
            {
                Text.SetActive(false);
                TextBox.SetActive(false);
            }
        }

        if (showedE == true)
        {
            E.gameObject.transform.Translate(0, 15 * Time.deltaTime, 0);
            E.color = new Color(A.color.r, A.color.g, A.color.b, e);
            e -= 2 * Time.deltaTime;
            if (e < 0)
            {
                E.gameObject.SetActive(false);
                Text.SetActive(false);
                TextBox.SetActive(false);
            }
        }
    }

}
