using UnityEngine;
using System.Collections;

public class espinho : MonoBehaviour {

    private GameObject Timer;
    private GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {

        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {


            //reduz o tempo da fase em 5 segundos.
            Timer.GetComponent<Timer>().timer -= 5f;

            //deve voltar para o ultimo checkpoint salvo e reduzir o tempo do jogo em um valor.
            colisor.gameObject.GetComponent<Transform>().position = GerenciadorJogo.GetComponent<GerenciadorJogo>().posicaoSalva;


        }
    }
}
