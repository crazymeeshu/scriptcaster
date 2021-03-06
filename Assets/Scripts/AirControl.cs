﻿using UnityEngine;
using System.Collections;

public class AirControl : MonoBehaviour {

    public string stringToEdit = "";
    public Transform ball;
    public Transform cube;
    public Transform cap;
    bool hasReturned = false;
    bool airUp = false;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasReturned == true)
        {
            if (stringToEdit.ToLower() == "ball")
            {
                Transform newball = (Transform)Instantiate(ball, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (stringToEdit.ToLower() == "cube")
            {
                Transform newcube = (Transform)Instantiate(cube, new Vector3(0, 0, 0), Quaternion.identity);
            }
            else if (stringToEdit.ToLower() == "cap")
            {
                Transform newcap = (Transform)Instantiate(cap, new Vector3(0, 0, 0), Quaternion.identity);
            }
            stringToEdit = "";
        }
    }

    void OnGUI()
    {
        GUI.SetNextControlName("Spellbook");
        Event e = Event.current;
        if (e.keyCode == KeyCode.Return)
        {
            hasReturned = true;
            airUp = false;
        }
        else if (e.keyCode == KeyCode.Alpha3)
        {
            airUp = true;
            hasReturned = false;
            stringToEdit = "";
            GUI.FocusControl("Spellbook");
        }
        else if (hasReturned == false && airUp == true)
            stringToEdit = GUI.TextField(new Rect(10, 10, 200, 20), stringToEdit, 25);
    }
}
