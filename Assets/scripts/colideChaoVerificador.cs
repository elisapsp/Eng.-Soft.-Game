using UnityEngine;
using System.Collections;

public class colideChaoVerificador : MonoBehaviour {

    private GameObject player;

    //colisaoPassiva = 0 se o Bug bateu no player (não foi por pulo).
    //colisaoPassiva = 1 se o Bug foi batido pelo player.
    public int colisaoPassiva = 0;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D colisor)
    {

        if (colisor.gameObject.tag == "Inimigo")
        {
            if (colisor.gameObject.GetComponent<BugCollision>().TipoBug != 3)
            {
                colisaoPassiva = 1;
                player.GetComponent<Rigidbody2D>().AddForce(transform.up * 400f);
                var vidaInimigo = colisor.gameObject.GetComponentInChildren<vidaObjeto>();
                vidaInimigo.PerdeVida(10);
            }
            else if (colisor.gameObject.GetComponent<BugCollision>().TipoBug == 3)
            {
                player.GetComponent<Transform>().position = new Vector3(0f, -0.7f, 0f);
                colisaoPassiva = 0;
                //TODO: colocar o player na ultima posicao do checkpoint.
            }
        }
        else
        {
            colisaoPassiva = 0;
        }
        
        
    }
    
}
