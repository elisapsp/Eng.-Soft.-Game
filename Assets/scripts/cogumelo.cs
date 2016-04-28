﻿using UnityEngine;
using System.Collections;

public class cogumelo : MonoBehaviour {

    public float forcaPulo = 200f;
    
    // Use this for initialization
    void Start () {

    

	}
	
	// Update is called once per frame
	void Update () {

 

    }


    //Quando algum objeto (colisor) enconstar no cogumelo, será arremessado para cima.
    //gameObject dá permissão para usar os atributos do objeto.
    //Rigidbody2D permite que aplique a forçça no personagem através de AddForce.
    //Essa força aplicada será para cima (transform.up)
    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player") {
            colisor.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }
    }

}
