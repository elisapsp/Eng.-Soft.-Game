using UnityEngine;
using System.Collections;

public class OnGameOver : MonoBehaviour {

    private GameObject GerenciadorJogo;
    private GameObject recursos;


    // Use this for initialization
    void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        recursos = GameObject.Find("GerenciarTime");
    }
	
	// Update is called once per frame
	void Update () {


        //Se tiver dado GameOver (ou seja, o Tempo do jogo ter chegado a 0).
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().GameOver == true)
        {
            //Aumenta o numero de dias trabalhados.
            GerenciadorJogo.GetComponent<GerenciadorJogo>().countDiasTrabalhados++;

            //Entra a fase de remanejamento (GameWait == true).
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameStart = false;
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait = true;
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameOver = false;

            //Reseta os recursos.
            recursos.GetComponent<Recursos>().resetaRecursos();

            //Aumenta em 'pontoExtra (variável pública)' o numero de pontosTotais.
            recursos.GetComponent<Recursos>().PontosTotais += GerenciadorJogo.GetComponent<GerenciadorJogo>().pontoExtra;



            //Coloca o jogador na posição inicial da fase.
            GerenciadorJogo.GetComponent<GerenciadorJogo>().player.position = GerenciadorJogo.GetComponent<GerenciadorJogo>().posicaoInicialPlayer;

        }

    }
}
