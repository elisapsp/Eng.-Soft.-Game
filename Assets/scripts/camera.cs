using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

    //Pegará a posição do objeto player.
    private Transform player;



	// Use this for initialization
	void Start () {

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
	
	// Update is called once per frame
	void Update () {

        //Vetor X,Y,Z.
        //X = posição do player em x.
        //Y = posição do player em y.
        //Z = mantem a posição da câmera.
        Vector3 novaPosicao = new Vector3(player.position.x, player.position.y, transform.position.z);

        //Lerp faz a movimentação da camera na posição que se encontra para a nova posição.
        transform.position = Vector3.Lerp(transform.position, novaPosicao, Time.time);
      
    }
}
