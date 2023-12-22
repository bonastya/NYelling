using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetVolume : MonoBehaviour
{
    
    public bool isPlayerHere=false;
    private void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            isPlayerHere = true;
            print("вошёл");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isPlayerHere = false;
            print("вышел");
        }
    }



}
