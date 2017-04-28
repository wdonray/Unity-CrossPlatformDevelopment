using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Encounter : MonoBehaviour
{
    //public UnityEngine.UI.Text Win_Text; 

    private Renderer rend;
    [SerializeField]
    private GameBehavior Goal_Test;
    private void Start()
    {
        Goal_Test = FindObjectOfType<GameBehavior>();
        rend = GetComponentInParent<Renderer>();
        //Goal_Test.GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rend.material.color = Random.ColorHSV();
            if (this.gameObject == Goal_Test.Goal)
            {
                Debug.Log("You win");
            }
        }
    }
}
