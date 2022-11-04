using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class CuritaManager : MonoBehaviourPun
{
    [SerializeField]
    private GameObject cura;
    [SerializeField]
    private Transform curitaSpawm;

    private float spawnTimeCurita;
    void Update()
    {
        if (photonView.IsMine && spawnTimeCurita > 10)
        {
            photonView.RPC("SetCura", RpcTarget.AllBuffered);
            spawnTimeCurita = 0;
        }

        spawnTimeCurita += Time.deltaTime;
    }
    
    [PunRPC]
    void SetCura()
    {
        Debug.Log("Colocando una cura");

        GameObject curita = GameObject.Instantiate(cura, curitaSpawm);
        
    }
}
