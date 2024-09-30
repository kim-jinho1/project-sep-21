using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FishNet;
using FishNet.Broadcast;
using FishNet.Connection;

public class ChatBroadcastGuide : MonoBehaviour
{
    public Transform chatHolder;
    public GameObject msgElement;
    public TMP_InputField playerUsername,playermessage;
    
    public struct  Message : IBroadcast
    {
        public string username;
        public string message;
    }
    
}
