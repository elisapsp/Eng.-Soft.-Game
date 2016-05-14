using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/**
	Salvar os estados do jogo:
	Objeto player.
	Inimigos vivos.
	Pacotes da fase.   
*/
public class controleVersao : MonoBehaviour {

	//Será o Log do commit.
	private string Log = "commit";
    private GameObject player;

	public GameObject CommitPrototype;
	private static int versionId = 0;

    void Start()
    {
        player = GameObject.Find("Player");
        GerenciadorJogo.instance.posicaoSalva = player.transform.position;
		GameObject newCommit = Instantiate(CommitPrototype);
		newCommit.GetComponentInChildren<Text>().text = Log + versionId; versionId++;
		newCommit.transform.SetParent(GerenciadorJogo.instance.CommitList, false);
		CommitInstance commitInstance = newCommit.GetComponent<CommitInstance>();
		commitInstance.Commit = this.gameObject;

    }
    
    

}
