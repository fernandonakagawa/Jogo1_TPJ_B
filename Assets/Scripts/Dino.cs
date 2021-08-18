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
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = this.transform.position;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 posicao = transform.position;
            posicao.x += velocidade;
            transform.position = posicao;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 posicao = transform.position;
            posicao.x -= velocidade;
            transform.position = posicao;
        }
        if (Input.GetKey(KeyCode.W) && tempoPulado <= 0)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            Vector2 forca = new Vector2(0f, 15f);
            rb.AddForce(forca, ForceMode2D.Impulse);
            tempoPulado = tempoPulo;
        }
        //Debug.Log(Time.deltaTime);
        tempoPulado -= Time.deltaTime;
        if(this.transform.position.y < -10f)
        {
            this.transform.position = posicaoInicial;
            audio.PlayOneShot(audioMorri);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dino"))
        {
            audio.PlayOneShot(audioUi);
        }
        if (collision.collider.CompareTag("Perigo"))
        {
            this.transform.position = posicaoInicial;
            audio.PlayOneShot(audioMorri);
        }
    }
}

