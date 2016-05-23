using UnityEngine;
using System.Collections;

public class lava : MonoBehaviour {

    private GameObject Timer;
    private GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {
        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");
    }

    // Update is called once per frame
    void Update() {



    }

    //É chamado quando o objeto que estiver com este script colidir(no exato momento) com algo
    //e a opção isTrigger estiver habilitada lá no Inspector do objeto que estiver com esse script. 
    //(A opção isTrigger permite  que outros objetos consigam passar por este objeto).
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {


            //reduz o tempo da fase em 5 segundos.
            Timer.GetComponent<Timer>().timer -= 5f;

            //deve voltar para o ultimo checkpoint salvo e reduzir o tempo do jogo em um valor.
            colisor.gameObject.GetComponent<Transform>().position = GerenciadorJogo.GetComponent<GerenciadorJogo>().posicaoSalva;


        }
        else if (colisor.gameObject.tag == "Inimigo")
        {
            
            colisor.gameObject.GetComponentInChildren<vidaObjeto>().PerdeVida(colisor.gameObject.GetComponentInChildren<vidaObjeto>().maxVida);
        }
    }
}
