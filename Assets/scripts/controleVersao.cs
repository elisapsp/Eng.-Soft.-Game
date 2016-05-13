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
    private GameObject Player;

    void Start()
    {
        Player = GameObject.Find("Player");
        GerenciadorJogo.instance.posicaoSalva = Player.transform.position;
    }
    
    

}
