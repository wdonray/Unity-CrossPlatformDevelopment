using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{

    public Text Log_Text;
    public Text Current_Pos;

    private Vector2 Pos;
    // Use this for initialization
    void Start()
    {
        Log_Text.text = "Welcome to Bright Souls 3";
        Pos = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Input_Check();
        Current_Pos.text = "Current Pos: " + Pos.ToString();
        if (Pos == new Vector2(1, 0))
            Log_Text.text = "You Here";

    }

    void Input_Check()
    {
        if (Input.GetKeyDown(KeyCode.A))
            Pos += new Vector2(-1, 0);
        else if (Input.GetKeyDown(KeyCode.D))
            Pos += new Vector2(1, 0);
        else if (Input.GetKeyDown(KeyCode.W))
            Pos += new Vector2(0, 1);
        else if (Input.GetKeyDown(KeyCode.S))
            Pos += new Vector2(0, -1);
    }
}
