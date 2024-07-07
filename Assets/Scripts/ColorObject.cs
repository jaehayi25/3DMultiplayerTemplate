using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ColorObject : NetworkBehaviour
{
    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        Debug.Log(NetworkManager.Singleton.LocalClient.PlayerObject); 
    }
}
