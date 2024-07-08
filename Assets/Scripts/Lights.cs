using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode; 

public class Lights : NetworkBehaviour
{


    [SerializeField] private GameObject[] lights;
    [SerializeField] private GameObject firework;

    private void Start()
    {
        foreach (GameObject light in lights)
        {
            light.SetActive(false); 
        }
        firework.SetActive(false); 
    }

    [ServerRpc(RequireOwnership = false)]
    public void TurnOnLightServerRpc(int lightIdx)
    {
        TurnOnLightClientRpc(lightIdx); 
    }

    [ClientRpc]
    private void TurnOnLightClientRpc(int lightIdx)
    {
        lights[lightIdx].SetActive(true);

        bool startFirework = true;
        foreach (GameObject light in lights) {
            if (!light.activeSelf)
            {
                startFirework = false;
            }
        }

        if (startFirework) firework.SetActive(true);
    }
}
