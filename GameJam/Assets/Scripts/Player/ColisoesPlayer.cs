using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisoesPlayer : MovimentacaoPlayer
{
    [Header("Colisores")]
    public int PlayerID;
    public Transform teleportePoint;
    GravidadeObjeto gravidadeObjeto;
    public GameObject cameraSegundoPlayer;
    public GameObject cameraUI;
    void Awake()
    {
        gravidadeObjeto = FindObjectOfType<GravidadeObjeto>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporte"))
        {
            this.transform.position = teleportePoint.transform.position;
        }
        if (collision.gameObject.CompareTag("Inversor"))
        {
            InverterColisao();
            gravidadeObjeto.InverterColisao();
        }
        if (collision.gameObject.CompareTag("CameraCol"))
        {
            cameraSegundoPlayer.SetActive(false);
            cameraUI.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CameraCol"))
        {
            cameraSegundoPlayer.SetActive(true);
            cameraUI.SetActive(true);
        }
    }
}
