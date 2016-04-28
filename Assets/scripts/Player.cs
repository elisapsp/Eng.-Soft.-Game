using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public GameObject Tiro1;
    public GameObject Tiro2;
    public float tempoRecargaArma  = 0.2f;
    private float tempoRecargaCorrenteArma;
    // Use this for initialization

    //0 = pulo duplo.
    //1 = Tiro1.
    //2 = Tiro2.
    public int nivelDebug = 0;

    public float direcao = 0;
    public float velocidade = 3;
    public float forcaPulo = 150;

    //pegará o conteúdo do objeto nerdGuy (no qual está setado todas as animações e etc).
    public Transform spritePlayer;
    private Animator animator;

    //Verifica se o personagem está no chão.
    private bool estaNoChao;
    private int maxJumps = 2;
    private int jumps = 0;

    //Pega a posição do objeto chaoVerificador.
    public Transform chaoVerificador;

    void Start () {

        //Quando o script for criado, vamos jogar as configurações da aba Animator referente ao nerdGuy na variável animator.
        animator = spritePlayer.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        Movimentacao();
        ArmaDebugger();
        reset();
	}

    void reset()
    {
        if (Input.GetKeyDown("r"))
        {
            restartCurrentScene();
        }
    }

    public void restartCurrentScene()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }



    void Movimentacao() {

        //Irá jogar dentro do parâmetro movimento, um valor 0 ou maior que 0.
        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));

        //estaNoChao recebe verdadeiro ou falso.
        //Analisa se entre o personagem (transform.position) e o objeto chaoVerificador (chaoVerificador.position)
        //existe algum conteúdo com o Layer Piso(1 << LayerMask.NameToLayer("Piso")).
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));

        //Seta o parâmetro chao do Animator com true ou false, caso o personagem esteja no chão ou não.
        animator.SetBool("chao", estaNoChao);

        //Se o player estiver no chão.
        if (estaNoChao)
        {
            //Seta o numero máximo de pulos no máximo.
            jumps = maxJumps;
            

        }
        direcao = Input.GetAxisRaw("Horizontal");
        //GetAxisRaw("Horizontal") é um método que retorna 1 quando pressionado a seta da direita e -1 quando pressionado a seta da esquerda.
        if (direcao > 0)
        {
            //transform é responsável por todas as ações e valores da seção transform do objeto (lá no inspector).
            //Translate significa que o objeto deve movimentar.
            //Vector2.right significa que deve movimentar para a direita.
            //Time.deltaTime garante que a velocidade do jogador seja comum a todos os jogadores (não depende da eficiência do processador de onde o jogo será executado).
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            //eulerAngles mexe com a rotação dos eixos X e Y.
            transform.eulerAngles = new Vector2(0,0);
        }

        if (direcao < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && jumps > 0)
        {

            //Decrementa o numero de pulos.
            jumps--;

            //Seta a velocidade y para 0, assim, o personagem não sobe muito caso aperte o botão de pular em intervalos de tempo pequeno.
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0);

            //Será aplicada uma força para cima(transform.up) contra a gravidade.
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);

            
        }


    }

    void ArmaDebugger()
    {
        tempoRecargaCorrenteArma += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) {
            

            if (tempoRecargaCorrenteArma >= tempoRecargaArma) { 

            if (nivelDebug == 1)
            {
                //Cria Tiro1
                Instantiate(Tiro1, transform.position, Tiro1.transform.rotation);

            }
            else if (nivelDebug == 2)
            {
                //Cria tiro2.
                Instantiate(Tiro2, transform.position, Tiro2.transform.rotation);
            }
            else
            {
                Debug.Log("Você precisa melhorar seu nível de Debug para ser utilizado desta forma.");
            }

                tempoRecargaCorrenteArma = 0;
            }


        }
    }

}
