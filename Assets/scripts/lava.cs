using UnityEngine;
using System.Collections;

public class lava : MonoBehaviour {

    private Transform player;

	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;

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

            //deve voltar para o ultimo checkpoint salvo e reduzir o tempo do jogo em um valor.
            player.position = new Vector3(0, 0, 0);
            

        }
    }
}
