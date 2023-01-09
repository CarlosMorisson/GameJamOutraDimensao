using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]private int valorFinalizar;
    private bool podeFinalizar;
    public ParticleSystem particulaFinal;
    [SerializeField] private int quantidadeDeBotoes;
    [SerializeField] private string proximaCena;
    Audios audio;
    MudancaDeCena mudaCena;
    void Start()
    {
        audio = FindObjectOfType<Audios>();
        mudaCena = FindObjectOfType<MudancaDeCena>();
    }
    void Update()
    {
        if (podeFinalizar)
            particulaFinal.Play();
        if (valorFinalizar == quantidadeDeBotoes)
        {
            podeFinalizar = true;
            audio.audioFinal.Play();
            audio.audioAmbiente.Pause();
            StartCoroutine(MudarCena());
        }
    }
    public int RecebeValorPressionado(int valorPressionado)
    {
        valorFinalizar += valorPressionado;
        return valorFinalizar;
    }
    IEnumerator MudarCena()
    {
        yield return new WaitForSeconds(5f);
        mudaCena.MudarDeCena(proximaCena);
    }
}
