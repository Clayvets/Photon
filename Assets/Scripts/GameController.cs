using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPun
{
    [SerializeField]
    private GameObject playerPrefab;
    [SerializeField]
    private Transform player1SpawnPoint;
    [SerializeField]
    private Transform player2SpawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        if (playerPrefab == null)
        {
            Debug.LogError("Falta la referencia al player prefab");
        }
        else
        {
            Transform spawnPoint = (PhotonNetwork.IsMasterClient) ? player1SpawnPoint : player2SpawnPoint;
            //El cliente maestro es quien crea la sala.    

            object[] initData = new object[1];
            initData[0] = "Data instaciacion";

            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, Quaternion.identity, 0, initData);
        }
    }
    
    

    // Update is called once per frame
    
}
