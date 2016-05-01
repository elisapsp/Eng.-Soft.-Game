using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {

	public Transform player;
	public Vector3 posicaoSalva;
	public static GerenciadorJogo instance; //singleton

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