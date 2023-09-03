using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Transform targetPosition;
    public Transform cameraTargetPosition;
    public LayerMask goldLayer;
    public float autoGetGoldRadius = 1f;
    int goldRemains;
    bool canGoNextLevel = true;

    void Awake()
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, autoGetGoldRadius, goldLayer);
        if (colls.Length > 0)
        {
            canGoNextLevel = false;
            goldRemains = colls.Length;
            foreach (Collider2D coll in colls)
            {
                coll.GetComponent<Gold>().OnCollected += ReduceGold;
            }
        }
    }

    private void ReduceGold(Gold gold)
    {
        goldRemains--;
        if (goldRemains == 0)
            canGoNextLevel = true;
        gold.OnCollected -= ReduceGold;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (canGoNextLevel)
            {
                if (cameraTargetPosition)
                {
                    other.transform.position = targetPosition.position;
                    CameraTarget.Instance.transform.position = cameraTargetPosition.position;
                }
            }
            else
            {
                Debug.Log("Collect All Golds!!");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, autoGetGoldRadius);
    }
}
