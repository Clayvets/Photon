using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;


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
    [SerializeField]
    /*private GameObject panelConnect;
    [SerializeField]
    private GameObject panelRoom;*/
    
    void Scake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
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

    /*void ShowRoomPanel()
    {
        GameObject.Find("PanelConnect").SetActive(false);
        panelRoom.SetActive(true);
    }*/

    /*public void SetColor(int index)
    {
        string color = GameObject.Find("DropDownColors").GetComponent<Dropdown>().options[index].text;
        
        Debug.Log("Color: " + color);

        var propsToSet = new ExitGames.Client.Photon.Hashtable() { { "color", color } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(propsToSet);
    }*/

    /* void SetReady()
    {
        var propsToSet = new ExitGames.Client.Photon.Hashtable() { { "ready", true } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(propsToSet);
    }*/
    
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

        //PhotonNetwork.LoadLevel("Game"); ////pa no compilar mucho

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("Sala lista");//lo tiene que llamar el master si no no da
            //PhotonNetwork.LoadLevel("Game");//ESTO SE COMENTA DESPUES
        }
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " Se a unido al cuarto, Player " + PhotonNetwork.CurrentRoom.PlayerCount);
        
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2 && PhotonNetwork.IsMasterClient)
        {
            Debug.Log("Sala llena*");//lo tiene que llamar el master si no no da
            PhotonNetwork.LoadLevel("Game");
            /*ShowRoomPanel();*/
        }
    }

    /*public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        Debug.Log("OnPlayerPropertiesUpdate");
        
        if (changedProps.ContainsKey("color"))
        {
            Debug.Log("Color");
            
            if (changedProps.ContainsKey("ready"))
            {
                Debug.Log("Ready");
                
                int playersReady = 0;
                foreach (var player in PhotonNetwork.CurrentRoom.Players.Values)
                {
                    bool ready = (bool)player.CustomProperties["ready"];
                    Debug.Log(player.NickName + "is ready? ..." + ready);

                    if (ready)
                    {
                        playersReady++;
                        Debug.Log("Cantidad players");
                    }

                    if (playersReady == PhotonNetwork.CurrentRoom.MaxPlayers)
                    {
                        PhotonNetwork.LoadLevel("Game");
                    }
                }
            }
        }
    }  */                                                                            

    #endregion
    
}
