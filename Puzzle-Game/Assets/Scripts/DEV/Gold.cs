using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gold : MonoBehaviour
{
    public Action<Gold> OnCollected;
    bool isDone;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isDone)
            return;

        if (other.TryGetComponent<PlayerManager>(out var playerManager))
        {
            isDone = true;
            playerManager.AddGold();
            OnCollected?.Invoke(this);
            Destroy(gameObject, 0.1f);
        }
    }
}
