using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Encounter : MonoBehaviour
{
    //public UnityEngine.UI.Text Win_Text; 

    private Renderer rend;
    [SerializeField]
    private GameBehavior Goal_Test;
    private bool Goal_Got;
    private void Start()
    {
        Goal_Test = FindObjectOfType<GameBehavior>();
        rend = GetComponentInParent<Renderer>();
        Goal_Got = false;
        //Goal_Test.GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rend.material.color = Random.ColorHSV();
            if (this.gameObject == Goal_Test.Goal)
            {
                Goal_Got = true;
                Debug.Log("You win");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        rend.material.color = Color.white;
    }
    private void Update()
    {
        if (Goal_Got == true)
        {
            rend.material.color = Random.ColorHSV();
            SceneManager.LoadScene("0.main");
        }
    }
}
