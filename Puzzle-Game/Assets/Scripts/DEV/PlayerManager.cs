using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] Int goldAmount;
    Vector3 startPos;
    PlayerHealth playerHealth;

    void Start()
    {
        startPos = transform.position;
        playerHealth = GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.OnBorn += Resposition;
        }
        goldAmount.Value = 0;
    }

    void OnDestroy()
    {
        if (playerHealth != null)
        {
            playerHealth.OnBorn -= Resposition;
        }
    }

    private void Resposition()
    {
        transform.position = startPos;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Checkpoint"))
        {
            ChangeCheckpoint(other.transform);
        }
    }

    private void ChangeCheckpoint(Transform checkpoint)
    {
        startPos = checkpoint.position;
    }

    public void AddGold()
    {
        goldAmount.Value += 1;
    }
}
