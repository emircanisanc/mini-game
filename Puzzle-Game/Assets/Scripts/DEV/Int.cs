using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Int")]
public class Int : ScriptableObject
{
    [SerializeField] int value;
    public int Value
    {
        get { return value; }
        set { this.value = value; OnValueChanged?.Invoke(this.value); }
    }
    public Action<int> OnValueChanged;
}
