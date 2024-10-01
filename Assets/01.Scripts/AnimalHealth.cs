using System.Collections;
using System.Collections.Generic;
using FishNet.CodeGenerating;
using UnityEngine;
using FishNet.Object.Synchronizing;
using FishNet.Object;
using TMPro;

public class AnimalHealth : NetworkBehaviour
{
    [AllowMutableSyncType]
    [SerializeField] 
    private SyncVar<int> _health = new SyncVar<int>(10, new SyncTypeSettings(1f));
    private TextMeshProUGUI healthText;

 
    private void Start()
    {
        healthText = GameObject.FindGameObjectWithTag("HealthText").GetComponent<TextMeshProUGUI>();
    }
 
    private void Update()
    {
        if (!base.IsOwner)
            return;
 
        healthText.text = _health.ToString();
    }
}
 