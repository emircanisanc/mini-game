using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Float")]
public class Float : ScriptableObject
{
    [SerializeField] float value;
    public float Value
    {
        get { return value; }
        set { this.value = value; OnValueChanged?.Invoke(this.value); }
    }
    public Action<float> OnValueChanged;

}
