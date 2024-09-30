using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;
using FishNet.Object;

public class CubePositionBroadcast : MonoBehaviour
{
    public List<Transform> cubePositions = new List<Transform>();
    public int transformIndex;
    
    private void OnEnable()
    { 
        //InstanceFinder.ClientManager.RegisterBroadcast<PositionIndex>(OnPositionBroadcast);
        //InstanceFinder.ClientManager.RegisterBroadcast<PositionIndex>(OnClientPositionBroadcast);
    }

    private void OnDisable()
    {
        //InstanceFinder.ClientManager.UnregisterBroadcast<PositionIndex>(OnPositionBroadcast);
        //InstanceFinder.ClientManager.UnregisterBroadcast<PositionIndex>(OnClientPositionBroadcast);

    }

    private void Update()
    {
        int nextIndex = transformIndex + 1;
        if (nextIndex >= cubePositions.Count)
        {
            nextIndex = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (InstanceFinder.IsServerStarted)
            {
                InstanceFinder.ServerManager.Broadcast(new PositionIndex() { tIndex = transformIndex + 1 });
            }
            else if (InstanceFinder.IsClientStarted)
            {
                InstanceFinder.ClientManager.Broadcast(new PositionIndex() { tIndex = transformIndex + 1 });
            }
        } 
        
        transform.position = cubePositions[transformIndex].position;
    }

    private void OnPositionBroadcast(PositionIndex indexStruct)
    {
        transformIndex = indexStruct.tIndex;
    }

    private void OnClientPositionBroadcast(NetworkConnection networkConnection,PositionIndex indexStruct)
    {
        InstanceFinder.ServerManager.Broadcast(indexStruct);
    }
    
    public struct PositionIndex : IBroadcast
    {
        public int tIndex;
    }
}
