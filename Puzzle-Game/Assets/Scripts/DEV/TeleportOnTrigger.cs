using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportOnTrigger : MonoBehaviour
{
    public Transform targetPos;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = targetPos.position;
        }
    }

}
