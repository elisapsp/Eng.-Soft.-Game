using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class atualizaTempoUso : MonoBehaviour {

    private string nomeRecurso;
    private GameObject Player;
    float tempoUsoTotal;
    // Use this for initialization
    void Start () {

        nomeRecurso = gameObject.name;
        Player = GameObject.Find("Player");
        tempoUsoTotal = Player.GetComponent<usaRecursos>().duracaoRecursos;

    }
	
	// Update is called once per frame
	void Update () {

        switch (nomeRecurso)
        {
            case "PraticasMotivacionais":
                
                if (Player.GetComponent<usaRecursos>().usandoPraticasMotivacionais == true)
                {
                    gameObject.GetComponent<Text>().color = Color.green;
                    float tempo = tempoUsoTotal - Player.GetComponent<usaRecursos>().tempoUsoPraticasMotivacionais;
                    gameObject.GetComponent<Text>().text = tempo.ToString("0");
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                    gameObject.GetComponent<Text>().text = "-";
                }
                
                break;

            case "AumentoSalario":
                if (Player.GetComponent<usaRecursos>().usandoAumentoSalario == true)
                {
                    gameObject.GetComponent<Text>().color = Color.green;
                    float tempo = tempoUsoTotal - Player.GetComponent<usaRecursos>().tempoUsoAumentoSalario;
                    gameObject.GetComponent<Text>().text = tempo.ToString("0");
                    
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                    gameObject.GetComponent<Text>().text = "-";
                }
                break;

            case "Cafe":
                if (Player.GetComponent<usaRecursos>().usandoCafe == true)
                {
                    gameObject.GetComponent<Text>().color = Color.green;
                    float tempo = tempoUsoTotal - Player.GetComponent<usaRecursos>().tempoUsoCafe;
                    gameObject.GetComponent<Text>().text = tempo.ToString("0");
                }
                else
                {
                    gameObject.GetComponent<Text>().color = Color.white;
                    gameObject.GetComponent<Text>().text = "-";
                }
                break;
            default:
                Debug.Log("O nome do Panel está diferente do nome escrito dentro do switch deste código [atualizaTempoUso].");
                break;
        }
        


    }
}
