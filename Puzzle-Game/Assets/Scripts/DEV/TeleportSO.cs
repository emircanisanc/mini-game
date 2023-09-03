using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Teleport Values")]
public class TeleportSO : ScriptableObject
{
    public Float teleportMaxTime;
    public Float teleportTime;
    public Float skillMaxDuration;    
    public Float skillDuration;
}
