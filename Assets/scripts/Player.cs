using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // Use this for initialization

   
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

        //GetAxisRaw("Horizontal") é um método que retorna 1 quando pressionado a seta da direita e -1 quando pressionado a seta da esquerda.
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            //transform é responsável por todas as ações e valores da seção transform do objeto (lá no inspector).
            //Translate significa que o objeto deve movimentar.
            //Vector2.right significa que deve movimentar para a direita.
            //Time.deltaTime garante que a velocidade do jogador seja comum a todos os jogadores (não depende da eficiência do processador de onde o jogo será executado).
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            //eulerAngles mexe com a rotação dos eixos X e Y.
            transform.eulerAngles = new Vector2(0,0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
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
}
