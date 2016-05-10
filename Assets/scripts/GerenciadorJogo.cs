using UnityEngine;
using System.Collections;

public class GerenciadorJogo : MonoBehaviour {

    /*
     Coloquei 3 estados: GameOver(Quando o tempo do jogo terminou),
                         GameWait(quando o jogo está parado, antes de começar, fase na qual o remanejamento de recursos é permitido),
                         GameStart (quando o jogo vai começar, mas não quando está em andamento).

      Se o jogo estiver acontecendo(em andamento), os 3 estados são falsos.
     */

    public int pontoExtra;
    public bool GameOver; //Quando o jogo der gameOver.
    public bool GameWait; //Enquanto o jogador não clicar em voltar ao jogo, no menu de Gerenciamento de Time.
    public bool GameStart; //Quando o jogador começar a jogar.

    public GameObject menuRecursos;
    private GameObject recursos;
    private GameObject Timer;

    public Transform player;
	public Vector3 posicaoSalva;
    public int countDiasTrabalhados;

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

    void Start()
    {

      //O jogo começa na fase de remanejamento dos recursos.
      GameOver = false;
      GameWait = true; 
      GameStart = false;
      
      
      recursos = GameObject.Find("GerenciarTime");
      Timer = GameObject.Find("Canvas/Timer/Panel/Text");
    }

	void Update() {
		if (Input.GetKeyDown("c")) {
			player.position = posicaoSalva;
		}

        //Se tiver dado GameOver (ou seja, o Tempo do jogo ter chegado a 0).
        if (GameOver == true)
        {
            //Aumenta o numero de dias trabalhados.
            countDiasTrabalhados++;

            //Entra a fase de remanejamento (GameWait == true).
            GameStart = false;
            GameWait = true;
            GameOver = false;

            

            //Aumenta em 'pontoExtra (variável pública)' o numero de pontosTotaisAbsolutos.
            recursos.GetComponent<Recursos>().PontosTotaisAbsoluto += pontoExtra;

            //Reseta os recursos.
            recursos.GetComponent<Recursos>().resetaRecursos();
            /*
            Falta:
            1 - Colocar o jogador na posição inicial da fase.
            2 - deletar todos os checkpoints.
             
            */
        }

        //Se tiver na fase de remanejamento de recursos..
        if (GameWait == true)
        {   
            
            GameStart = false;
            GameOver = false;

            //Coloca o menu de gerenciamento de recursos aparecendo.
            menuRecursos.SetActive(true);
        }

        //Se não tiver no GameOver, e nem no estado de espera (quando é possivel remanejar recursos) e o jogo for começar.
        if (GameWait == false && GameOver == false && GameStart == true)
        {
            //Seta o tempo denovo.
            Timer.GetComponent<Timer>().timer = Timer.GetComponent<Timer>().tempoInicial;
            GameStart = false;
        }
	}

    //Essa função é chamada pelo botão Sair do Menu, dentro do menu de gerenciamento de recursos.
    public void ReadyToStartGame()
    {
        //Se tiver na fase de remanejamento.
        if (GameWait == true && GameOver == false && GameStart == false) {

            //Sai da fase de remanejamento.
            GameWait = false;
            //Inicia o jogo.
            GameStart = true;
        }

    }


}

