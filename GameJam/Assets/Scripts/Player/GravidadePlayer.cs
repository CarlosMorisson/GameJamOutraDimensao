using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravidadePlayer : MonoBehaviour
{
    public Rigidbody2D rig;
    public bool estaEmbaixo;
    public float jumpForce = 5f;
    [HideInInspector] public Audios audio;
    void Start()
    {
        audio = FindObjectOfType<Audios>();
        if (estaEmbaixo)
            InverterColisao();
    }

   public void InverterColisao()
    {
        rig.gravityScale *= -1;
        Vector3 localScale = transform.localScale;
        localScale.y *= -1f;
        transform.localScale = localScale;
        jumpForce *= -1;
    }
}
