using UnityEngine;
using System.Collections;

public class bolaFogo : MonoBehaviour {

    private float posicaoY = 0f;

	// Use this for initialization
	void Start () {

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
}
