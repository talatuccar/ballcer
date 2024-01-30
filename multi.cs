using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Pun.Demo.Cockpit.Forms;
using TMPro;
using UnityEngine.SceneManagement;

public class multi : MonoBehaviourPunCallbacks
{
    //public TextMeshProUGUI inputCreate;
    //public TextMeshProUGUI inputJoin;
    //string CreateInput;
    public TMP_InputField nick_input;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        DontDestroyOnLoad(gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        Check_playerList();
    }

    //public override void OnConnectedToMaster()
    //{
    //    PhotonNetwork.JoinLobby();
    //}



    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
        SceneManager.LoadScene(1);
    }
    //public void CreateRoom()
    //{
    //    if (inputCreate.text != "")
    //    {
    //        CreateInput = inputCreate.text;
    //        RoomOptions roomOptions = new RoomOptions();
    //        roomOptions.IsVisible = true;
    //        roomOptions.MaxPlayers = 2;
    //        PhotonNetwork.JoinOrCreateRoom(CreateInput, roomOptions, TypedLobby.Default);
    //        SceneManager.LoadScene(1);
    //    }
    //    else if(inputJoin.text == CreateInput)
    //    {
    //        PhotonNetwork.JoinRoom(CreateInput);
    //        SceneManager.LoadScene(1);
    //    }


    //}

    public override void OnJoinedRoom()
    {
        GameObject myplayer = PhotonNetwork.Instantiate("player", Vector3.zero, Quaternion.identity, 0, null);
        myplayer.GetComponent<PhotonView>().Owner.NickName = nick_input.textComponent.text;
        //myplayer.GetComponent<PhotonView>().GetComponent<Renderer>().material.color= Color.red;
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("theroom", roomOptions, TypedLobby.Default);
        SceneManager.LoadScene(1);
    }


    private void Check_playerList()
    {

        if (PhotonNetwork.PlayerList.Length == 2)
        {
            GameObject.FindWithTag("nickname").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;
            GameObject.FindWithTag("nickname_other").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[1].NickName;

        }
        if (PhotonNetwork.PlayerList.Length == 1)



        {

            GameObject.FindWithTag("nickname").GetComponent<TextMeshProUGUI>().text = PhotonNetwork.PlayerList[0].NickName;

        }



    }
}
