using UnityEngine;
using System.Collections;

public class colideChaoVerificador : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
	
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
                var vidaInimigo = colisor.gameObject.GetComponentInChildren<vidaObjeto>();
                vidaInimigo.PerdeVida(10);
            }
            else if(colisor.gameObject.GetComponent<BugCollision>().TipoBug == 3)
            {
               
                //TODO: colocar o player na ultima posicao do checkpoint.
            }
        }
        
        
    }
    
}
