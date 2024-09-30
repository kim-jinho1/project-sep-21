using System;
using System.Collections;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using Unity.Mathematics;
using UnityEngine;

public class PlayerSpawnObject : NetworkBehaviour
{
    public GameObject objToSpawn;
    [HideInInspector] public GameObject spawnedObject;
    
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            GetComponent<PlayerSpawnObject>().enabled = false;
        }
    }

    private void Update()
    {
        if (spawnedObject == null && Input.GetKeyDown(KeyCode.Alpha1))
        {
            SpawnObject(objToSpawn, transform, this);
        }
        if (spawnedObject != null && Input.GetKeyDown(KeyCode.Alpha2))
        {
            DepawnObject(spawnedObject);
        }
    }

    [ServerRpc]
    public void SpawnObject(GameObject obj,Transform player, PlayerSpawnObject script)
    {
        GameObject spawned = Instantiate(obj, player.position + player.forward,quaternion.identity);
        ServerManager.Spawn(spawned);
        SetSpawnedObject(spawned,script);
    }

    [ObserversRpc]
    public void SetSpawnedObject(GameObject spawned, PlayerSpawnObject script)
    {
        script.spawnedObject = spawned;
    }

    [ServerRpc(RequireOwnership = false)]
    public void DepawnObject(GameObject obj)
    {
        ServerManager.Despawn(obj);
    }
}
