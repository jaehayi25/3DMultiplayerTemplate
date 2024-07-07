using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 
using StarterAssets; 

public class Mind : MonoBehaviour
{
    [SerializeField]
    GameObject[] Players;

    GameObject CurrentPlayer;

    void Start()
    {
        foreach (GameObject player in Players) {
            EnablePlayer(player, false); 
        }
    }

    public void ChangePlayer(GameObject player)
    {
        EnablePlayer(CurrentPlayer, false);

        CurrentPlayer = player;
        EnablePlayer(CurrentPlayer, true); 
    }
    
    private void EnablePlayer(GameObject player, bool enable)
    {
        player.GetComponent<ThirdPersonController>().enabled = enable;
        player.GetComponent<PlayerInput>().enabled = enable;
        player.GetComponent<CharacterController>().enabled = enable;
    }
}
