using UnityEngine;
using System.Collections;

public class Recursos : MonoBehaviour {

    public int desenvolvedores; //Numero de desenvolvedores (quantidade de pedaco de software que pode carregar).
    public bool[] testador = new bool[4]; //Testadores de cada tipo de software.
    public int controleVersao; //NumeroDeCheckpoints
    public int nivelDebug; //Arma: 0 = pulo (default). 1 = tiro1. 2 = tiro2.
    public bool ConhecimentoSCRUM; //Pulo Duplo
    public int OrganizacaoTempo; //+Tempo
    public int aumentoSalario; //PuloMaisAlto
    public int PraticasMotivacionais; //+ velocidade
    public int Cafe; //+ velocidade.

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
