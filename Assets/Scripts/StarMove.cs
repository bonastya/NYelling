using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    public Vector2 direction;




    void Awake() 
    { 
        rb = gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D; 
        rb.bodyType = RigidbodyType2D.Kinematic; 
    }

    private void Start()
    {
        float rotx = 1;// Random.Range(0f, 360f);
        float roty = 1;//Random.Range(0f, 360f);
        /*CameraScript sc = gameObject.AddComponent<CameraScript>() as CameraScript;
        sc.gameManager = gameManager;*/
        gameObject.transform.Translate(-1.0f, 0.0f, -2.0f);
        
        //direction = new Vector2(rotx, roty);
        
        //transform.Rotate(0, 0, Mathf.Sqrt(rotx * rotx+ roty* roty));


        //transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));

        
    }



    void Update()
    {
        rb.velocity = new Vector2(-4.0f, -2.0f);
        //rb.velocity = rb.velocity * speed * Time.deltaTime;
        /*transform.Translate(speed * direction * Time.deltaTime, Space.World);*/
    }
}
