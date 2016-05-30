using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToggleBotoesMenuJogador : MonoBehaviour {

    private GameObject[] BotoesMenuJogador;
    private GameObject GerenciadorJogo;

    void toggleBotoesMenuJogador()
    {

        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait == true)
        {
            foreach (GameObject botao in BotoesMenuJogador)
            {
                botao.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            foreach (GameObject botao in BotoesMenuJogador)
            {
                botao.GetComponent<Button>().interactable = true;
            }
        }
    }

    // Use this for initialization
    void Start () {
        BotoesMenuJogador = GameObject.FindGameObjectsWithTag("BotaoMenuJogador");
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
    }
	
	// Update is called once per frame
	void Update () {

        //Se tiver na fase de GameWait, os botões (exceto o sair) não funcionarão.
        toggleBotoesMenuJogador();

    }
}
