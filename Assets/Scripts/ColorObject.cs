using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class ColorObject : NetworkBehaviour
{
    [SerializeField]
    private int colorId;

    private Renderer meshRenderer; 

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        PlayerData playerData = GameMultiplayer.Instance.GetPlayerDataFromClientId(NetworkManager.Singleton.LocalClient.ClientId);

        meshRenderer = GetComponent<Renderer>();
        meshRenderer.material.SetColor("_BaseColor", GameMultiplayer.Instance.GetPlayerColor(colorId));

        // Debug.Log(GameMultiplayer.Instance.GetPlayerColor(colorId)); 

        bool visible = (colorId == playerData.colorId);
        if (visible)
        {
            Show(); 
        }
        else
        {
            Hide(); 
        }
    }

    private void Show()
    {
        GetComponent<MeshRenderer>().enabled = true;
    }

    private void Hide()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
