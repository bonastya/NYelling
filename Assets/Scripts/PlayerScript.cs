using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public GameManager gameManager;
    public Vector3 moveVector;
    public Rigidbody2D player;
    public float jumpForce;
    public bool isRotate = false;

    //public Animator m_Animator;

    private float MaxVol = 0f;


    private float startPosX;
    private float gravity;
    private float volume;
    

    void Start()
    {
        moveVector = new Vector3(1,0,0);
        startPosX = transform.position.x;
        //StartCoroutine(VolCor());
    }


    // Update is called once per frame
    void Update()
    {
        
        if (gameManager.isGameStart)
        {
            transform.Translate(moveVector * gameManager.moveSpeed * Time.deltaTime);

            if (transform.position.y < 1.5)
            {
                gravity = 0;
            }
            else
            {
                gravity = 0.05f;
                //gravity = 0.02f;
            }

            volume = transform.position.y+((float)MicInput.MicLoudness) * 10 * 5 / gameManager.maxVolume - gravity;

            if (volume < 34)
            {
                transform.SetPositionAndRotation(transform.position + new Vector3(0, ((float)MicInput.MicLoudness) * 10*5 / gameManager.maxVolume - gravity, 0), transform.rotation);

            }
            else
            {
                
            }









            //transform.position.y += (float)MicInput.MicLoudness * 100;

            //transform.Translate(Vector3.up * (float)MicInput.MicLoudness*100 * Time.deltaTime);


            //gameManager.score = Math.Ceiling(transform.position.x - startPosX);
            if (Input.GetButtonDown("Jump"))
            {
                print("прыг");
                //m_Animator.Play("PlayerJump"); 
                player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//добавляем импульс вверх
                
            }


            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//добавляем импульс вверх
                    
                }
            }



        }
        


    }


    IEnumerator VolCor()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            //player.transform.position = player.transform.position + Vector3.up* (float)(Math.Round(MicInput.MicLoudness, 1));
            //player.
            player.AddForce(Vector2.up * (float)(Math.Round(MicInput.MicLoudness , 1)), ForceMode2D.Impulse);//добавляем импульс вверх

            
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Obstacle")
            gameManager.GameOver(0);
        if (collision.gameObject.tag == "CheckPoint")
            gameManager.GameOver(1);

        

    }





}
