using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Float timer;

    void Start()
    {
        timer.Value = 0f;
    }

    void Update()
    {
        timer.Value += Time.deltaTime;    
    }
}
