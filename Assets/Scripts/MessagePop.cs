using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagePop : MonoBehaviour
{
    
    public GameObject Message;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") Message.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player") Message.SetActive(false);
    }

}
