using UnityEngine;
using System.Collections;

public class checkGameResult : MonoBehaviour {

    private GameObject score;
    private GameObject IntroSpeaking;
    public int goalScore;
    public string texto0;
    public string texto1;
    public string texto2;
    // Use this for initialization
    void Start () {
        
        score = GameObject.Find("score");
        IntroSpeaking = GameObject.Find("IntroSpeaking");
        texto0 = "texto";
        texto1 = "texto";
        texto2 = "texto";

        if (score != null)
        {

        if (score.GetComponent<readScore>().score <= goalScore)
          {
                texto0 = "Estou bastante satisfeita com o resultado.";
                texto1 = "Você e sua equipe se mostraram extremamente eficientes e ágeis. ";
                texto2 = "Muito obrigada. Está aqui o seu pagamento.";
            }
        else
        {
           texto0 = "Infelizmente vocês não me entregaram no prazo que combinamos.";
           texto1 = "Sendo assim, não irei pagar pelo software.";
           texto2 = "Irei atrás de outra empresa que cumpra com o prometido. Muito obrigada.";
        }
        
        }

    }



    // Update is called once per frame
    void Update () {

    }
}
