using UnityEngine;
using System.Collections;

public class DaDano : MonoBehaviour {

    public int dano;
    public bool destroiAtacante;

	// Use this for initialization
	void Start () {
       

	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            var player = colisor.gameObject.GetComponent<vidaObjeto>();
            player.PerdeVida(dano);

            if (destroiAtacante)
            { 
                Destroy(gameObject);
            }
        }
    }
    
}
