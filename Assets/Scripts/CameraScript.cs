using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameManager gameManager;
    public Vector3 moveVector;
    void Start()
    {
        moveVector = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameStart) 
        { 
            transform.Translate(moveVector * gameManager.moveSpeed * Time.deltaTime);
        }
            
    }
}
