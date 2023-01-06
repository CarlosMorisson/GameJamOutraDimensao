using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Transform pivotPos;

    public object main { get; internal set; }
    void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(transform.position, pivotPos.position, 0.1f);
    }
}
