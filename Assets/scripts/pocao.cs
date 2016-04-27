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
        if (colisor.gameObject.tag == "Player")
        {
            var player = colisor.gameObject.GetComponent<vidaObjeto>();
            player.RecuperaVida(vida);
            Destroy(gameObject);
        }
    }

}
