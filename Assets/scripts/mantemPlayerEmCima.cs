using UnityEngine;
using System.Collections;

public class mantemPlayerEmCima : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //Se o objeto player(colisor) continuar colidindo com a plataforma.
    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            //Então os valores do transform (posicao da plataforma) irá herdar os mesmos valores do transform da plataforma.
            //O pai do transform do player será o transform da plataforma. Ou seja, 
            //O transform do player herdará(será filho) o transform da plataforma.
            colisor.gameObject.transform.parent = transform;
        }
    }

    //Se o objeto player(colisor) sair/deixar de colidir da plataforma.
    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            //Então, o transform do player deixará de seguir as características do objeto atual.
            colisor.gameObject.transform.parent = null;
          
        }
    }
}
