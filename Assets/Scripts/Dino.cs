using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = this.transform.position;
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //andar para frente ou para trás
        if (Input.GetKey(KeyCode.D)) Andar(true);
        if (Input.GetKey(KeyCode.A)) Andar(false);

        if (Input.GetKey(KeyCode.W) && tempoPulado <= 0) Pular();
        tempoPulado -= Time.deltaTime;

        VerificarMorte();
        AtualizarAnimacao();
    }

    void Andar(bool paraFrente)
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
    void Pular()
    {
        animator.SetBool("estaPulando", true);
        Vector2 forca = new Vector2(0f, 15f);
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
            audio.PlayOneShot(audioMorri);
            animator.SetBool("estaMorrendo", true);
        }
        if (collision.collider.CompareTag("Chao"))
        {
            animator.SetBool("estaPulando", false);
        }
    }

    void AtualizarAnimacao()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            animator.SetBool("estaAndando", true);
        }
        else
        {
            animator.SetBool("estaAndando", false);
        }
    }
}

