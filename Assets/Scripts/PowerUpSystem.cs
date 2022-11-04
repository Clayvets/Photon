using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PowerUpSystem : MonoBehaviourPun, IOnEventCallback
{
    private const byte cureEventCode = 1;
    //[SerializeField] GameObject prefab;
    //float time; 
    //float cooldown = 10;
    //int current_pos, counter;
    //Transform[] spawns;
    
    private void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    
    private void Start()
    {
        //counter = 1; robadooo
        if (PhotonNetwork.IsMasterClient)
        {
            GenerateCure();
        }
    }

    private void GenerateCure()
    {

        RaiseEventOptions eventOptions = new RaiseEventOptions { Receivers = ReceiverGroup.All,CachingOption= EventCaching.AddToRoomCache };

        PhotonNetwork.RaiseEvent(cureEventCode,null,eventOptions, SendOptions.SendReliable);
        
    }

    public void OnEvent(EventData photonEvent)
    {
        if(photonEvent.Code == cureEventCode)
        {
            Debug.Log("curita");
            //GameObject.Instantiate(); con esto se haceeee!
            
            //ESTO ES ROBADO XD hay que cambiarlo
            //time = 0;
            //spawns = GameObject.Find("Spawnpoints_PowerUps").GetComponentsInChildren<Transform>();
            //Instantiate(prefab, spawns[current_pos].position, Quaternion.identity);
            //current_pos++;
            //if (current_pos >= spawns.Length-1) current_pos = 0;
            //counter = 1;
        }
    }
    
}
