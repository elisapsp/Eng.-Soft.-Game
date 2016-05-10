using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {

	public Transform player;
	public Vector3 posicaoSalva;
	public static GerenciadorJogo instance; //singleton

    //Contador de bugs tipo 3. É incrementado no inicio da fase, quando os bugs são criados. E é decrementado sempre que um bug crítico é destruido.
    public int numBugsCriticos;

    //Contador de GameOvers.
    public int numDiasTrabalhados;

	void Awake() {
		if (instance != null) {
			Debug.LogError("GerenciadorJogo deve ter uma unica instancia");
		}
		instance = this;
	}

	void Update() {
		if (Input.GetKeyDown("c")) {
			player.position = posicaoSalva;
		}
	}
}