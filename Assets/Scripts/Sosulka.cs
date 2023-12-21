using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sosulka : MonoBehaviour
{

    private HeartControl heartControl;
    private void Start()
    {
        heartControl = GameObject.FindFirstObjectByType<HeartControl>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        print("�� ��������"+ other.gameObject);
        if (other.gameObject.tag == "Player")
        {
            print("��������");
            gameObject.SetActive(false);
            heartControl.HealthDecrease();
        }
    }
}
