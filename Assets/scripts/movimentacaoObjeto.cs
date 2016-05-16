﻿using UnityEngine;
using System.Collections;

public class movimentacaoObjeto : MonoBehaviour {

    //movimentação vertical.
    public bool vertical;

    //movimentação horizontal (padrão.)
    public bool horizontal;

    //Inidica a velocidade do objeto.
    public float velocidade;

    //Tempo que o objeto irá durar na mesma posicao, antes de inverter de lado.
    public float duracaoPosicao;

    //Tempo que ele ainda está na mesmaPosicao;
    public float tempo;

    //Guarda a direcao que o objeto está andando.
    //1 = direita.
    //-1 = esquerda.
    public int direcao;

    // Use this for initialization
    void Start()
    {

        if (vertical == false && horizontal == false)
        {
            horizontal = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        MovimentacaoObjeto();
    }

    void MovimentacaoObjeto()
    {
        //Aumenta o tempo que esta na posiçao atual
        tempo += Time.deltaTime;

        //Se o tempo 
        if (tempo >= duracaoPosicao)
        {
            //Zera contagem
            tempo = 0;

            //Muda a posiçao
            if (direcao == 1)
            {
                direcao = -1;
            }
            else
            {
                direcao = 1;
            }
        }
        //movimenta
        if (direcao == 1)
        {
            if (horizontal) { 
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.up * velocidade * Time.deltaTime);
            }
        }
        else
        {
            if (horizontal)
            {
                transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.down * velocidade * Time.deltaTime);
            }
        }
    }
}
