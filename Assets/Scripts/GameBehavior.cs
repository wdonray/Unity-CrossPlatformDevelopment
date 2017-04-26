using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn Boxes Behavior
public class GameBehavior : MonoBehaviour
{

    public List<GameObject> Boxes;
    public int Box_Number;
    public string Say;
    public GameObject Box_Prefab;

    // Use this for initialization
    void Start()
    {
        Log();
        Boxes = new List<GameObject>();
    }
    private void Update()
    {
        GameObject Box;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Log();
            Box = Instantiate(Box_Prefab) as GameObject;
            Boxes.Add(Box);
            Box_Number++;
            Renderer color = Box.GetComponent<Renderer>();
            color.material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
        }
    }
    void Log()
    {
        Debug.Log(Say + " " + Box_Number);
    }
}
