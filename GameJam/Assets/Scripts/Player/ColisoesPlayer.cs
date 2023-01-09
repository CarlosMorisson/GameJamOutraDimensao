using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisoesPlayer : MovimentacaoPlayer
{
    [Header("Colisores")]
    public Transform teleportePoint;
    GravidadeObjeto gravidadeObjeto;
    BotaoFinalizar finalizar;
    public GameObject cameraSegundoPlayer;
    public GameObject cameraUI;
    [SerializeField] private ParticleSystem particulaTeleporte;
    void Awake()
    {
        gravidadeObjeto = FindObjectOfType<GravidadeObjeto>();
        finalizar = FindObjectOfType<BotaoFinalizar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Teleporte"))
        {
            if (PlayerID == 2)
            {
                this.transform.position = teleportePoint.transform.position;
                particulaTeleporte.Play();
                audio.audioTeleporte.Play();
            }
        }
        if (collision.gameObject.CompareTag("Inversor"))
        {
            InverterColisao();
            gravidadeObjeto.InverterColisao(PlayerID);
        }
        if (collision.gameObject.CompareTag("CameraCol"))
        {
            cameraSegundoPlayer.SetActive(false);
            cameraUI.SetActive(false);
        }
        if (collision.gameObject.CompareTag("Botao"))
        {
            finalizar.pressionado = true;
            finalizar.Pressionado();
            audio.audioBotao.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("CameraCol"))
        {
            cameraSegundoPlayer.SetActive(true);
            cameraUI.SetActive(true);
        }
        if (collision.gameObject.CompareTag("Botao"))
        {
            finalizar.pressionado = false;
            finalizar.Pressionado();
        }
    }
}
