using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Log : MonoBehaviour
{

    public Text Log_Text;
    public Text Current_Pos;

    private Vector2 Pos;
    private Vector2 Goal;
    private Dictionary<Vector2, GameObject> Nodes = new Dictionary<Vector2, GameObject>();
    private GameObject go;

    // Use this for initialization
    void Start()
    {
        Log_Text.text = "Welcome to Bright Souls 3";
        Pos = new Vector2(0, 0);
        while (Goal == Pos)
        {
            Goal = new Vector2((Random.Range(0, 5)), (Random.Range(0, 5)));
        }
        Grid();
    }

    // Update is called once per frame
    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        Nodes[Pos].GetComponent<Renderer>().material.color = Color.magenta;
        Nodes[Goal].GetComponent<Renderer>().material.color = Color.yellow;

        Input_Check();

        Current_Pos.text = "Current Pos\n  " + Pos.ToString();

        if (Pos == Goal)
            Log_Text.text = "You Here";
        else
            Log_Text.text = "You are not here";
    }

    void Input_Check()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (Pos.x > 0)
            {
                Nodes[Pos].GetComponent<Renderer>().material.color = Color.white;
                Pos += new Vector2(-1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (Pos.x < 4)
            {
                Nodes[Pos].GetComponent<Renderer>().material.color = Color.white;
                Pos += new Vector2(1, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            if (Pos.y < 4)
            {
                Nodes[Pos].GetComponent<Renderer>().material.color = Color.white;
                Pos += new Vector2(0, 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
            if (Pos.y > 0)
            {
                Nodes[Pos].GetComponent<Renderer>().material.color = Color.white;
                Pos += new Vector2(0, -1);
            }
    }
    void Grid()
    {
        int count = 0;
        for (var i = 0; i < 5; i++)
            for (var j = 0; j < 5; j++)
            {
                count += 1;
                Vector2 v = new Vector2(i, j);
                go = GameObject.CreatePrimitive(PrimitiveType.Quad);
                go.transform.position = new Vector3(v.x, v.y, go.transform.position.z);
                Nodes.Add(v, go);
            }
    }
}
