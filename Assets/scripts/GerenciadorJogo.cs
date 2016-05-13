using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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

    public bool objetivoConcluido; //Quando o jogador conseguir realizar todos os objetivos, essa variável é setada como true.

    public GameObject menuRecursos;
    private GameObject recursos;
    private GameObject Timer;

    public Transform player;
	public Vector3 posicaoSalva;
    public Vector3 posicaoInicialPlayer;
    public int countDiasTrabalhados;

    private GameObject PlayerController;
    private GameObject[] BotoesMenuJogador;
    private GameObject[] PopUpMenus;

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
        //salva a posição inicial do player.
        posicaoInicialPlayer = player.position;

        posicaoSalva = posicaoInicialPlayer;

        //O jogo começa na fase de remanejamento dos recursos.
        GameOver = false;
      GameWait = true; 
      GameStart = false;
        objetivoConcluido = false;
        PlayerController = GameObject.Find("Player");
        recursos = GameObject.Find("GerenciarTime");
      Timer = GameObject.Find("Canvas/Timer/Panel/Text");

         BotoesMenuJogador = GameObject.FindGameObjectsWithTag("BotaoMenuJogador");
       
}

    void togglefreezePlayer()
    {
        if (Timer.GetComponent<Timer>().freeze == true || GameWait == true)
        {
            PlayerController.GetComponent<Player>().enabled = false;
        }
        else
        {
            PlayerController.GetComponent<Player>().enabled = true;
        }
    }

    void toggleBotoesMenuJogador()
    {

        if (GameWait == true)
        {
            foreach (GameObject botao in BotoesMenuJogador)
            {
                botao.GetComponent<Button>().interactable = false;
            }
        }
        else
        {
            foreach (GameObject botao in BotoesMenuJogador)
            {
                botao.GetComponent<Button>().interactable = true;
            }
        }
    }

    void FreezeTime()
    {
        PopUpMenus = GameObject.FindGameObjectsWithTag("PopUpMenu");
        if (PopUpMenus.Length > 0)
        {
            Timer.GetComponent<Timer>().freeze = true;
        }
        else
        {
            Timer.GetComponent<Timer>().freeze = false;
        }
    }

	void Update() {

       
        

        if (Input.GetKeyDown("c")) {
			player.position = posicaoSalva;
		}
        //Se algum painel estiver ativado, o tempo congela. Isso facilitará o jogo.
        FreezeTime();

        //Se o tempo tiver parado, o jogador congela.
        togglefreezePlayer();

        //Se tiver na fase de GameWait, os botões (exceto o sair) não funcionarão.
        toggleBotoesMenuJogador();

        //Se tiver dado GameOver (ou seja, o Tempo do jogo ter chegado a 0).
        if (GameOver == true)
        {
            //Aumenta o numero de dias trabalhados.
            countDiasTrabalhados++;

            //Entra a fase de remanejamento (GameWait == true).
            GameStart = false;
            GameWait = true;
            GameOver = false;

            //Reseta os recursos.
            recursos.GetComponent<Recursos>().resetaRecursos();

            //Aumenta em 'pontoExtra (variável pública)' o numero de pontosTotais.
            recursos.GetComponent<Recursos>().PontosTotais += pontoExtra;

            

            //Coloca o jogador na posição inicial da fase.
            player.position = posicaoInicialPlayer;

            /*
            Falta:
            
             1 - deletar todos os checkpoints.
        
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

