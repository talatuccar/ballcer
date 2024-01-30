using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounce : MonoBehaviour
{
    Rigidbody2D gameBall;
    public float wallPower;
    void Start()
    {
        gameBall = GameObject.FindWithTag("ball").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("ball"))
        {

            Vector2 poz = collision.GetContact(0).normal;
            gameBall.velocity=(poz*wallPower);    
        }
    }
}
