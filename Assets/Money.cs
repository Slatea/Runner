using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    GameManager Manager;
    private void Start()
    {
        Manager = GameObject.FindGameObjectWithTag("GameController").gameObject.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            Manager.MoneyAdd();
            Destroy(this.gameObject); 
        }
    }
}
