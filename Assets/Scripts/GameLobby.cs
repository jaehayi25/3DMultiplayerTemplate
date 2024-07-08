using System.Collections;
using System.Collections.Generic;
using Unity.Services.Authentication; 
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class GameLobby : MonoBehaviour
{
    public static GameLobby Instance { get; private set; }

    private Lobby joinedLobby; 

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

        InitializeUnityAuthentication(); 
    }

    private async void InitializeUnityAuthentication()
    {
        if (UnityServices.State != ServicesInitializationState.Initialized)
        {
            InitializationOptions initializationOptions = new InitializationOptions();
            initializationOptions.SetProfile(Random.Range(0, 10000).ToString());

            await UnityServices.InitializeAsync(initializationOptions);

            await AuthenticationService.Instance.SignInAnonymouslyAsync();

        }
    }

    public async void CreateLobby(string lobbyName, bool isPrivate)
    {
        try
        {
            joinedLobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, GameMultiplayer.MAX_PLAYER_AMT, new CreateLobbyOptions
            {
                IsPrivate = isPrivate,
            });
        } catch (LobbyServiceException e)
        {
            Debug.Log(e); 
        }
    }
}
