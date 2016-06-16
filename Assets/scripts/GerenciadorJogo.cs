using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GerenciadorJogo : MonoBehaviour {

    /*
     Coloquei 3 estados: GameOver(Quando o tempo do jogo terminou),
                         GameWait(quando o jogo está parado, antes de começar, fase na qual o remanejamento de recursos é permitido),
                         GameStart (quando o jogo vai começar, mas não quando está em andamento).

      Se o jogo estiver acontecendo(em andamento), os 3 estados são falsos.
     */
    public GameObject score;
    public GameObject cliente;
    public string nomeFase;
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

   
    
    

    public static GerenciadorJogo instance; //singleton

    //Contador de bugs tipo 3. É incrementado no inicio da fase, quando os bugs são criados. E é decrementado sempre que um bug crítico é destruido.
    public int numBugsCriticos;

    //Contador de GameOvers.
    public int numDiasTrabalhados;

	public Transform CommitList;

	void Awake() {

        

		if (instance != null) {
			Debug.LogError("GerenciadorJogo deve ter uma unica instancia");
		}
		instance = this;

        nomeFase = SceneManager.GetActiveScene().name;

    }

    void Start()
    {
		//salva a posição inicial do player.
		posicaoInicialPlayer = player.position;

		posicaoSalva = posicaoInicialPlayer;

        //O jogo começa na fase de remanejamento dos recursos.

        if (nomeFase == "test3")
        {
            GameOver = false;
            GameWait = false;
            GameStart = true;
        }
        else
        {
            GameOver = false;
            GameWait = true;
            GameStart = false;

        }
        objetivoConcluido = false;
		
		recursos = GameObject.Find("GerenciarTime");
		Timer = GameObject.Find("Canvas/Timer/Panel/Text");
        score = GameObject.Find("score");
        cliente = GameObject.Find("Cliente");
        if (nomeFase == "test2" || nomeFase == "test3")
        {
            if (score != null) { 
            countDiasTrabalhados = score.GetComponent<readScore>().score;
            }
        }
		
       
}



	private GameObject oldCommit = null;
   

	public void RestorePosition(GameObject commit) {
		player.position = commit.transform.position;
        posicaoSalva = player.position;
		commit.GetComponentInChildren<SpriteRenderer>().color = Color.black;
		if (oldCommit)
			oldCommit.GetComponentInChildren<SpriteRenderer>().color= Color.white;
		oldCommit = commit;

		//A cada git checkout, o jogador perde 5 segundos do tempo da fase.
		Timer.GetComponent<Timer>().timer -= 5.0f;

    }

    public void goBackToLastPosition()
    {
        if (Input.GetKeyDown("c") && CommitList.childCount > 0)
        {
            player.position = posicaoSalva;
        }
    }

	void Update() {
        
        goBackToLastPosition();
 
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

