using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MineSystem : MonoBehaviourPun
{
    [SerializeField] private GameObject mina;

    [SerializeField] private float CD = 30;

    private float timeCD;
    // Update is called once per frame

    private void Start()
    {
        timeCD = CD;
    }

    void Update()
    {
        if (photonView.IsMine && Input.GetKeyUp(KeyCode.Return) && timeCD > CD)
        {
            photonView.RPC("SetMine", RpcTarget.AllBuffered);
            timeCD = 0;
        }

        timeCD += Time.deltaTime;

    }

    [PunRPC]
    void SetMine()
    {
        Debug.Log("Colocando una mina");
        //se usa este... no usar photonview.instantiate NO
        
        GameObject minita = GameObject.Instantiate(mina, this.transform);
        minita.transform.parent = null;
    }
    
}
