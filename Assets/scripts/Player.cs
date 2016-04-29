using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private GameObject recursos;

    private int nivelDebug;
    public GameObject Tiro1;
    public GameObject Tiro2;
    public float tempoRecargaArma  = 0.2f;
    private float tempoRecargaCorrenteArma;

    public float duracaoRecursos = 3.0f;

    private float tempoUsoCafe;
    private bool usandoCafe;
    private float velocidadeCafe = 0f;
    
    private float tempoUsoPraticasMotivacionais;
    private bool usandoPraticasMotivacionais;
    private float velocidadePraticasMotivacionais = 0f;

    private float forcaAumentoSalario = 0f;
    private bool usandoAumentoSalario;
    private float tempoUsoAumentoSalario;

    public float direcao = 0;
    public float velocidadeInicial = 2; //Velocidade sem adição de recursos.
    public float velocidade; //velocidade do jogador.

    public float forcaPuloInicial = 150;
    public float forcaPulo;    




    //pegará o conteúdo do objeto nerdGuy (no qual está setado todas as animações e etc).
    public Transform spritePlayer;
    private Animator animator;

    //Verifica se o personagem está no chão.
    private bool estaNoChao;
    private int maxJumps = 1;
    private int jumps = 0;

    //Pega a posição do objeto chaoVerificador.
    public Transform chaoVerificador;

    void Start () {

        //Quando o script for criado, vamos jogar as configurações da aba Animator referente ao nerdGuy na variável animator.
        animator = spritePlayer.GetComponent<Animator>();
        recursos = GameObject.Find("Main Camera/GerenciarTime");
        velocidade = velocidadeInicial;
        forcaPulo = forcaPuloInicial;
    }
	
	// Update is called once per frame
	void Update () {
        usoAumentoSalario();
        usoCafe();
        usoPraticasMotivacionais();
        Movimentacao();
        ArmaDebugger();
        TreinamentoSCRUM();
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

        velocidade = velocidadeInicial + velocidadeCafe + velocidadePraticasMotivacionais;
        forcaPulo = forcaPuloInicial + forcaAumentoSalario;

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


    void usoAumentoSalario()
    {
        tempoUsoAumentoSalario += Time.deltaTime;

        //Se estiver carregado pronto para uso.
        if (tempoUsoAumentoSalario >= duracaoRecursos)
        {
            //Se já estiver usando (significa que acabou o tempo de uso).
            if (usandoAumentoSalario == true)
            {
                //Seta usando == false.
                usandoAumentoSalario = false;
                //Coloca a forca adicional em 0.
                forcaAumentoSalario = 0f;
                //Deixa pronto para usar novamente.
                tempoUsoAumentoSalario = duracaoRecursos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (recursos.GetComponent<Recursos>().aumentoSalario > 0)
            {
                if (tempoUsoAumentoSalario >= duracaoRecursos)
                {


                    forcaAumentoSalario = 100f;
                    usandoAumentoSalario = true;
                    //Consome o recurso.
                    recursos.GetComponent<Recursos>().aumentoSalario--;
                }

            }
            else
            {
                Debug.Log("Não há recursos para aumento de salário.");
            }
            tempoUsoAumentoSalario = 0f;
        }
    }

    void usoCafe()
    {
        tempoUsoCafe += Time.deltaTime;

        //Se estiver carregado pronto para uso.
        if (tempoUsoCafe >= duracaoRecursos)
        {
            //Se já estiver usando (significa que acabou o tempo de uso).
            if (usandoCafe == true)
            {
                //Seta usando == false.
                usandoCafe = false;
                //Coloca a velocidade em 0.
                velocidadeCafe = 0f;
                //Deixa pronto para usar novamente.
                tempoUsoCafe = duracaoRecursos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (recursos.GetComponent<Recursos>().Cafe > 0)
            {
                   if (tempoUsoCafe >= duracaoRecursos)
                    {
                

                    velocidadeCafe = 1.0f;
                    usandoCafe = true;
                    //Consome o recurso.
                    recursos.GetComponent<Recursos>().Cafe--;
                }
                
            }
            else
            {
                Debug.Log("Não há mais Café.");
            }
            tempoUsoCafe = 0f;
        }

    }



    void usoPraticasMotivacionais()
    {
        tempoUsoPraticasMotivacionais += Time.deltaTime;

        //Se estiver carregado pronto para uso.
        if (tempoUsoPraticasMotivacionais >= duracaoRecursos)
        {
            //Se já estiver usando (significa que acabou o tempo de uso).
            if (usandoPraticasMotivacionais == true) {
                //Seta usando == false.
                usandoPraticasMotivacionais = false;
                //Coloca a velocidade em 0.
                velocidadePraticasMotivacionais = 0f;
                //Deixa pronto para usar novamente.
                tempoUsoPraticasMotivacionais = duracaoRecursos;
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (recursos.GetComponent<Recursos>().PraticasMotivacionais > 0)
            {
                if (tempoUsoPraticasMotivacionais >= duracaoRecursos)
                {
                

                    velocidadePraticasMotivacionais = 1.0f;
                    usandoPraticasMotivacionais = true;
                    //Consome o recurso.
                    recursos.GetComponent<Recursos>().PraticasMotivacionais--;
                }
                
            }
            else
            {
                Debug.Log("Não há mais recursos para PraticasMotivacionais.");
            }
            tempoUsoPraticasMotivacionais = 0f;
        }

    }

   

    //Tiros
    void ArmaDebugger()
    {
        nivelDebug = recursos.GetComponent<Recursos>().nivelDebug;
        tempoRecargaCorrenteArma += Time.deltaTime;

        if (tempoRecargaCorrenteArma >= tempoRecargaArma)
        {
            tempoRecargaCorrenteArma = tempoRecargaArma;
        }

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

                tempoRecargaCorrenteArma = 0f;
            }


        }
    }

    //Pulo Duplo
    void TreinamentoSCRUM()
    {

        if (recursos.GetComponent<Recursos>().ConhecimentoSCRUM == true)
        {
            maxJumps = 2;
        }
        else
        {
            maxJumps = 1;
        }

    }

}
