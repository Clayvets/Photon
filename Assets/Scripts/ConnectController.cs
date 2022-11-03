using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;


public enum RegionCodes
{
    AUTO,
    CAE,
    EU,
    US,
    USW,
    SA
}
public class ConnectController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private string gameVersion = "1";
    [SerializeField]
    private string regionCode = null;
    void Start()
    {
        
    }

    public void SetRegion(int index)
    {
        RegionCodes region = (RegionCodes)index;

        if (region == RegionCodes.AUTO)
        {
            regionCode = null;
        }
        else
        {
            regionCode = region.ToString();
        }
        
        Debug.Log("Region seleccionada: "+regionCode);
        PhotonNetwork.PhotonServerSettings.AppSettings.FixedRegion = regionCode;
    }
    
    public void Connect()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
        }
    }

    void SetButton(bool state, string msg)
    {
        GameObject.Find("Button").GetComponentInChildren<Text>().text = msg;
        GameObject.Find("Button").GetComponent<Button>().enabled = state;
    }

    #region MonoBehaviourPunCallbacks
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster() was called by PUN");
        SetButton(true, "QUE COMIENCEN LOS PUTAZOS!");
    }
    
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarningFormat("OnConnectedToMaster() was called by PUN with reason {0}", cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("OnJoinRandomFailed() was called by PUM. No random room available, so we create one. \nCalling: PhotoNetwork.CreateRoom");

        PhotonNetwork.CreateRoom(null, new RoomOptions());
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("PUM Basics Tutorial/Launcher: OnJoinedRoom() called by PUM. Now this client is in a room.");
        SetButton(false, "ESPERANDO ANDO a los jugadores");

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("Sala lista");
            PhotonNetwork.LoadLevel("Game");
        }
        
    }
    
    #endregion
    
}
