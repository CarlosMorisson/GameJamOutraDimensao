using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravidadeObjeto : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rig;
    public int idObject;
    private float transformPos;
    [SerializeField] private ParticleSystem particula;
    [HideInInspector] public Audios audio;
    BotaoFinalizar botao;
    void Start()
    {
        botao = FindObjectOfType<BotaoFinalizar>();
        audio = FindObjectOfType<Audios>();
        rig = GetComponent<Rigidbody2D>();
        transformPos = transform.position.x;
    }
    public void InverterColisao(int playerId)
    {
        if(playerId==idObject)
            rig.gravityScale *= -1;
        if (transform.position.x != transformPos)
        {
            StartCoroutine(particulas());
        }
    }
    IEnumerator particulas()
    {
        yield return new WaitForSeconds(1f);
        transformPos = transform.position.x;
        particula.Play();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Botao"))
        {
            botao.pressionado = true;
            botao.Pressionado();
            audio.audioBotao.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Botao"))
        {
            botao.pressionado = false;
            botao.Pressionado();
        }
    }
}
