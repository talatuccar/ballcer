using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public int speedforce;
    //public int ballforce;
    //public GameObject ball;
    Rigidbody2D rb;
    public float ballstayforce;
    public float ballforce;
    PhotonView pw;

    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pw = GetComponent<PhotonView>();

        if (PhotonNetwork.IsMasterClient)
        {

            if (pw.IsMine)
                GetComponent<Renderer>().material.color = Color.red;

            transform.position = new Vector3(-10,0,0);
            if (!pw.IsMine)
            {
                GetComponent<Renderer>().material.color = Color.blue;
            }
            //GameObject.FindWithTag("nickname").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("input_Red");

        }
        else
        {
            if (pw.IsMine)
                GetComponent<Renderer>().material.color = Color.blue;
            transform.position = new Vector3(10, 0, 0);
            if (!pw.IsMine)
            {
                GetComponent<Renderer>().material.color = Color.red;
            }
            //GameObject.FindWithTag("nickname_other").GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetString("input_Red");
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pw.IsMine)
        {
            BallMove();
        }
    }


    private void BallMove()
    {
        float inputx = Input.GetAxis("Horizontal");
        float inputy = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputx * speedforce, inputy * speedforce, 0);

        rb.velocity = movement;

    }


   

}


