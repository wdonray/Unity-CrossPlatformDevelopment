using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Spawn Boxes Behavior
public class GameBehavior : MonoBehaviour
{

    public List<GameObject> Boxes;
    public string Say;
    public GameObject Box_Prefab;
    public int dims;
    public int Box_Count;
    public GameObject Player;
    
    public GameObject Goal;
    // Use this for initialization
    void Start()
    {
        Boxes = new List<GameObject>();
        Create();
        Goal = Boxes[Random.Range(0, Boxes.Count)].transform.GetChild(0).gameObject;
        Goal.GetComponentInParent<Renderer>().material.color = Color.yellow;
        Box_Count = 0;
        Log();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
            Delete();
    }
    void Log()
    {
        Debug.Log(Say + " " + Box_Count);
    }
    void Create()
    {
        GameObject Box;

        for (int i = 0; i < dims; i++)
        {
            for (int j = 0; j < dims; j++)
            {
                Box = Instantiate(Box_Prefab) as GameObject;
                GameObject GameObj_Trigger = new GameObject();
                GameObj_Trigger.transform.parent = Box.transform;
                Box.transform.position = Box.transform.position;
                BoxCollider GameObj_Collider = GameObj_Trigger.AddComponent<BoxCollider>();
                GameObj_Collider.center = new Vector3(0, 1.5f, 0);
                GameObj_Collider.size = new Vector3(1, 1, 1);
                GameObj_Collider.isTrigger = true;
                GameObj_Collider.name = "Trigger";
                GameObj_Trigger.AddComponent<Encounter>();
                Boxes.Add(Box);
                Box.transform.position = new Vector3(i * 1.1f, 0, j * 1.1f);
            }
        }
        Player.GetComponent<Rigidbody>().useGravity = true;
        Box_Count = Boxes.Count;
        //Goal = Boxes[Random.Range(0, Boxes.Count)].transform.GetChild(0).gameObject;
        Goal = Boxes[0].transform.GetChild(0).gameObject;
        Log();
    }
    void Delete()
    {
        foreach (GameObject g in Boxes)
        {
            DestroyImmediate(g);
        }
       // Player.transform.position = new Vector3(5, 5, 5);
    }
}
//if (Input.GetKeyDown(KeyCode.Space))
//{
//    //Log();
//    //Box = Instantiate(Box_Prefab) as GameObject;
//    //Boxes.Add(Box);
//    //Box_Number++;
//    //Renderer color = Box.GetComponent<Renderer>();
//    //color.material.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
//}
