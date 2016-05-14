using UnityEngine;
using System.Collections;

public class CommitInstance : MonoBehaviour {

	/**
	 * Commit é uma referência para um objeto controle de versão colocado no mapa.
	 * Esse objeto deve conter todo o estado que deseja-se salvar.
	*/
	public GameObject Commit;

	public void RestoreState() {
		GerenciadorJogo.instance.RestorePosition(Commit);
	}
}
