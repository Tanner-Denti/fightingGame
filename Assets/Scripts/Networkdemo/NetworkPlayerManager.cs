using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DilmerGames.Core.Singletons;
using Unity.Netcode;

public class NetworkPlayerManager : NetworkSingleton<NetworkPlayerManager>
{
    NetworkVariable<int> playersInGame = new NetworkVariable<int>();

    public int PlayersInGame
    {
        get
        {
            return playersInGame.Value;
        }
    }

    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += (id) =>
        {
            if(IsServer)
                playersInGame.Value++;
        };

        NetworkManager.Singleton.OnClientDisconnectCallback += (id) =>
        {
            if(IsServer)
                playersInGame.Value--;
        };
    }
}