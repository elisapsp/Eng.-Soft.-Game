using UnityEngine;
using System.Collections;

public class bolaFogo : MonoBehaviour {

    private float posicaoY = 0f;
    private GameObject Timer;
    private GameObject GerenciadorJogo;

    // Use this for initialization
    void Start () {


        GerenciadorJogo = GameObject.Find("GerenciadorJogo");
        Timer = GameObject.Find("Canvas/Timer/Panel/Text");

        //Depois que este objeto for criado, será destruido em 2 segundos.
        Destroy(gameObject, 2f);

        //Assim qeu for criado, irá dar um salto de 400f (força do pulo).
        GetComponent<Rigidbody2D>().AddForce(transform.up * 400f);

        //guarda a posicao Y  de quando o objeto foi criado.
        posicaoY = transform.position.y;

    }
	
	// Update is called once per frame
	void Update () {

        //Se a bola de fogo estiver descendo
        if (posicaoY > transform.position.y)
        {

            transform.eulerAngles = new Vector2(180, 0);

        }
        posicaoY = transform.position.y;
	
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {

            //reduz o tempo da fase em 5 segundos.
            Timer.GetComponent<Timer>().timer -= 5f;

            //TODO: Substituir isso para colocar o player na ultima posicao do checkpoint.
            colisor.gameObject.GetComponent<Transform>().position = GerenciadorJogo.GetComponent<GerenciadorJogo>().posicaoSalva;
           

           

        }
    }
}
