using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravidadeObjeto : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }
    public void InverterColisao()
    {
        rig.gravityScale *= -1;
    }
}
