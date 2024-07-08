using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode; 

public class LightPressurePlate : NetworkBehaviour
{
    [SerializeField] private int lightIndex;
    [SerializeField] Lights lights; 

    private void OnTriggerEnter(Collider other)
    {
        lights.TurnOnLightServerRpc(lightIndex);
        ActivatePressurePlateServerRpc();
    }

    [ServerRpc(RequireOwnership = false)]
    public void ActivatePressurePlateServerRpc()
    {
        ActivatePressurePlateClientRpc();
    }

    [ClientRpc]
    private void ActivatePressurePlateClientRpc()
    {
        Renderer meshRenderer = GetComponent<Renderer>();
        meshRenderer.material.SetColor("_BaseColor", Color.green);
    }
}
