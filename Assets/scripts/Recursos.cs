﻿using UnityEngine;
using System.Collections;

public class Recursos : MonoBehaviour {


        

    public int PontosTotais = 20;
    public int minInt = 0;
    public bool minBool = false;
    public int desenvolvedores; //Numero de desenvolvedores (quantidade de pedaco de software que pode carregar).
    public int maxDesenvolvedores = 3;
    public bool[] testador = new bool[4]; //Testadores de cada tipo de software.
    public bool maxTestador1 = true;
    public bool maxTestador2 = true;
    public bool maxTestador3 = true;
    public bool maxTestador4 = true;
    public int controleVersao; //NumeroDeCheckpoints
    public int maxControleVersao = 10;
    public int nivelDebug; //Arma: 0 = pulo (default). 1 = tiro1. 2 = tiro2.
    public int maxNivelDebug = 2;
    public bool ConhecimentoSCRUM; //Pulo Duplo
    public bool maxConhecimentoSCRUM = true;
    public int OrganizacaoTempo; //+Tempo
    public int maxOrganizacaoTempo = 10;
    public int aumentoSalario; //PuloMaisAlto
    public int maxAumentoSalario = 10;
    public int PraticasMotivacionais; //+ velocidade
    public int maxPraticasMotivacionais = 10;
    public int Cafe; //+ velocidade.
    public int maxCafe = 10;

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
