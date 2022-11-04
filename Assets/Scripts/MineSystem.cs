using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class MineSystem : MonoBehaviourPun
{
    [SerializeField] private GameObject mina;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine && Input.GetKeyUp(KeyCode.Return))
        {
            photonView.RPC("SetMine", RpcTarget.AllBuffered);
        }

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
