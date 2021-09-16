using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    public float velocidade;
    public float tempoPulo;
    private float tempoPulado;
    private Vector3 posicaoInicial;
    private AudioSource audio;
    public AudioClip audioUi;
    public AudioClip audioMorri;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator animator;
    private int qtdCogubelos;
    public GameObject textoQtdCogubelos;
    private int qtdVidas;
    public GameObject textoVidas;
    public GameObject textoGameOver;
    private bool andarFrente, andarTras;

    //hp
    public GameObject barraVida;
    private int qtdHP;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = this.transform.position;
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        qtdCogubelos = 0;
        qtdVidas = 3;
        
        andarFrente = false;
        andarTras = false;
        qtdHP = 99;

        AtualizarHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (qtdVidas > 0)
        {
            //andar para frente ou para trás
            if (Input.GetKey(KeyCode.D) || andarFrente) Andar(true);
            if (Input.GetKey(KeyCode.A) || andarTras) Andar(false);

            if (Input.GetKey(KeyCode.W) && tempoPulado <= 0) Pular();
            tempoPulado -= Time.deltaTime;

            VerificarMorte();
            AtualizarAnimacao();
        }
        else
        {
            textoGameOver.gameObject.SetActive(true);
        }
    }

    public void AtualizarVida(int adicionarVida)
    {
        qtdHP += adicionarVida;
        if(qtdHP <= 0)
        {
            qtdVidas--;
            qtdHP = 100;
            audio.PlayOneShot(audioMorri);
            animator.SetBool("estaMorrendo", true);
        }
        if (qtdHP > 100) qtdHP = 100;
        if (qtdVidas < 0) qtdVidas = 0;
        AtualizarHUD();
    }

    public void Andar(bool paraFrente)
    {
        if(paraFrente)
        {
            sprite.flipX = false;
            Vector3 posicao = transform.position;
            posicao.x += velocidade;
            transform.position = posicao;
        }
        else
        {
            sprite.flipX = true;
            Vector3 posicao = transform.position;
            posicao.x -= velocidade;
            transform.position = posicao;
        }
    }
    public void AndarPressionado(bool paraFrente)
    {
        if (paraFrente) andarFrente = true;
        else andarTras = true;
    }
    public void AndarSoltar(bool paraFrente)
    {
        if (paraFrente) andarFrente = false;
        else andarTras = false;
    }

    public void Pular()
    {
        animator.SetBool("estaPulando", true);
        Vector2 forca = new Vector2(0f, 18f);
        rb.AddForce(forca, ForceMode2D.Impulse);
        tempoPulado = tempoPulo;
    }
    void VerificarMorte()
    {
        if (this.transform.position.y < -10f)
        {
            this.transform.position = posicaoInicial;
            audio.PlayOneShot(audioMorri);
        }  
    }

    public void Reviver()
    {
        animator.SetBool("estaMorrendo", false);
        this.transform.position = posicaoInicial;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dino"))
        {
            audio.PlayOneShot(audioUi);
        }
        if (collision.collider.CompareTag("Perigo"))
        {
            //this.transform.position = posicaoInicial;
            /*audio.PlayOneShot(audioMorri);
            animator.SetBool("estaMorrendo", true);

            Destroy(collision.gameObject);
            qtdVidas--;*/
            audio.PlayOneShot(audioUi);
            Destroy(collision.gameObject);
            AtualizarVida(-30);
            AtualizarHUD();
        }
        if (collision.collider.CompareTag("Chao"))
        {
            animator.SetBool("estaPulando", false);
        }
        if (collision.collider.CompareTag("cogumelo_bom"))
        {
            Destroy(collision.gameObject);
            qtdCogubelos++;
            //qtdCogubelos += 1;
            AtualizarVida(5);
            AtualizarHUD();
        }
        /*if (collision.collider.CompareTag("inimigo") && 
            !animator.GetBool("estaMorrendo"))
        {
            audio.PlayOneShot(audioMorri);
            animator.SetBool("estaMorrendo", true);

            //Destroy(collision.gameObject);
            qtdVidas--;
            AtualizarHUD();
        }*/
    }

    void AtualizarAnimacao()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || 
            andarFrente || andarTras)
        {
            animator.SetBool("estaAndando", true);
        }
        else
        {
            animator.SetBool("estaAndando", false);
        }
    }

    void AtualizarHUD()
    {
        textoQtdCogubelos.GetComponent<Text>().text = qtdCogubelos.ToString();
        textoVidas.GetComponent<Text>().text = qtdVidas.ToString();
        barraVida.GetComponent<RectTransform>().localScale = new Vector3((float)qtdHP/100,1,1);
    }
}

