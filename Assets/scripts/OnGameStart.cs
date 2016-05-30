using UnityEngine;
using System.Collections;

public class OnGameStart : MonoBehaviour {

    private GameObject GerenciadorJogo;
    private GameObject Timer;

    // Use this for initialization
    void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");
    }
	
	// Update is called once per frame
	void Update () {

        //Se não tiver no GameOver, e nem no estado de espera (quando é possivel remanejar recursos) e o jogo for começar.
        if (GerenciadorJogo.GetComponent<GerenciadorJogo>().GameWait == false && GerenciadorJogo.GetComponent<GerenciadorJogo>().GameOver == false && GerenciadorJogo.GetComponent<GerenciadorJogo>().GameStart == true)
        {
            //Seta o tempo denovo.
            Timer.GetComponent<Timer>().timer = Timer.GetComponent<Timer>().tempoInicial;
            GerenciadorJogo.GetComponent<GerenciadorJogo>().GameStart = false;
        }

    }
}
