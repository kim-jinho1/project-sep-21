using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using FishNet.CodeGenerating;

public class PlayerHealth : NetworkBehaviour
{
    [AllowMutableSyncType]
    [SerializeField]
    private SyncVar<int> _health = new SyncVar<int>(10, new SyncTypeSettings(1f));
    
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (!base.IsOwner)
        {
            GetComponent<PlayerHealth>().enabled = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            UpdateHealth(-1);
        }
    }

    [ServerRpc]
    public void UpdateHealth( int amountTochange)
    {
        _health.Value += amountTochange;
    }
}
