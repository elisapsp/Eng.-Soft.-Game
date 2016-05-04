using UnityEngine;
using System.Collections;

/**
	Salvar os estados do jogo:
	Objeto player.
	Inimigos vivos.
	Pacotes da fase.   
*/
public class controleVersao : MonoBehaviour {

	//Será o Log do commit.
	public string Log;

	public void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.name == "Player") { 
		GerenciadorJogo.instance.posicaoSalva = collider.transform.position;
		print(Log);
        }
    }

}
