using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableTeleportOnTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.DisableTeleport();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.EnableTeleport();
        }
    }
}
