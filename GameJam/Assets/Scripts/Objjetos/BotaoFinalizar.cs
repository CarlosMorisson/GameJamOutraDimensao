using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotaoFinalizar : MonoBehaviour
{
    [SerializeField] public bool podeFinalizar;
    public bool pressionado;
    private int numeroPressionado;
    GameController controller;
    private void Start()
    {
        controller = FindObjectOfType<GameController>();
    }
    public void Pressionado()
    {
        if (this.pressionado)
        {
            this.numeroPressionado = 1;
            controller.RecebeValorPressionado(this.numeroPressionado);
            Vector3 localScale = this.transform.localScale;
            //localScale.y -= 0.5f;
            this.transform.localScale = localScale;
        }
        else
        {
            this.numeroPressionado = -1;
            controller.RecebeValorPressionado(this.numeroPressionado);
            Vector3 localScale = transform.localScale;
            //localScale.y += 0.5f;
            this.transform.localScale = localScale;
        }
    }
}
