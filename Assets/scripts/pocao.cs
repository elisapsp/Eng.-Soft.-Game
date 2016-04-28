using UnityEngine;
using System.Collections;

public class pocao : MonoBehaviour {
    
    public int vida;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player" || colisor.gameObject.name == "chaoVerificador")
        {
            //pega o componente vidaObjeto dentro do player.
            var player = colisor.gameObject.GetComponentInChildren<vidaObjeto>();
            //player.RecuperaVida(vida);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.name == "chaoVerificador")
        {
            //pega o componente vidaObjeto dentro do player.
            var player = colisor.gameObject.GetComponentInChildren<vidaObjeto>();
            //player.RecuperaVida(vida);
            Destroy(gameObject);
        }
    }

}
