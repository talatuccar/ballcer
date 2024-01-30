
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ball : MonoBehaviour
{
    public int ballforce;
    public int ballstayforce;
    Rigidbody2D rb;
    public Transform parentTransform;
    public TextMeshProUGUI score_red;
    public TextMeshProUGUI score_blue;
    int redScoreNumber;
    int blueScoreNumber;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    //public void trns()
    //{
    //    transform.Translate(transform.position.x * ballforce, transform.position.y * ballforce, 0);
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            transform.SetParent(parentTransform);
            if (Input.GetKey(KeyCode.X))
            {
                //Vector3 direction = collision;
                //ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.position * ballforce);
                Vector3 poz = collision.GetContact(0).normal;
                rb.velocity = (poz * ballstayforce);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            transform.SetParent(parentTransform);
            if (Input.GetKey(KeyCode.X))
            {
                //Vector3 direction = collision;
                //ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.position * ballforce);
                Vector3 poz = collision.GetContact(0).normal;
                rb.velocity = (poz * ballforce);
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.CompareTag("red_goal"))
        {

            redScoreNumber++;
            score_red.text = redScoreNumber.ToString();
        }



        if (collision.CompareTag("blue_goal"))
        {

            blueScoreNumber++;
            score_blue.text = blueScoreNumber.ToString();
        }



    }


}