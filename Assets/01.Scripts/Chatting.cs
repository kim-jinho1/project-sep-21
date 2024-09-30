using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Broadcast;
using FishNet;
using FishNet.Connection;

//Made by Bobsi Unity - for Youtube
public class Chatting : MonoBehaviour
{
    public List<Transform> cubePositions = new List<Transform>();
    public int transformIndex;

    private void OnEnable()
    {
        InstanceFinder.ClientManager.BroadcastMessage("ss");
       
    }

    private void OnDisable()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            int nextIndex = transformIndex + 1;
            if (nextIndex >= cubePositions.Count)
                nextIndex = 0;

            if(InstanceFinder.IsServerStarted)
            {
                InstanceFinder.ServerManager.Broadcast(new PositionIndex() { tIndex = nextIndex });
            }
            else if(InstanceFinder.IsClientStarted)
            {
                InstanceFinder.ClientManager.Broadcast(new PositionIndex() { tIndex = nextIndex });
            }
        }

        transform.position = cubePositions[transformIndex].position;
    }

    private void OnPositionBroadcast(PositionIndex indexStruct)
    {
        transformIndex = indexStruct.tIndex;
    }

    private void OnClientPositionBroadcast(NetworkConnection networkConnection, PositionIndex indexStruct)
    {
        InstanceFinder.ServerManager.Broadcast(indexStruct);
    }

    public struct PositionIndex : IBroadcast
    {
        public int tIndex;
    }
}