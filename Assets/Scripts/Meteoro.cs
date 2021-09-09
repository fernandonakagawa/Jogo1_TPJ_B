using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public GameObject dino;
    public float velocidade;
    public GameObject explosao;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>()
            .AddForce(new Vector2(-6f, 0), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector3 posicaoDino = dino.transform.position;
        Vector3 posicaoMeteoro = this.transform.position;
        if (posicaoDino.x > posicaoMeteoro.x) posicaoMeteoro.x += velocidade;
        else posicaoMeteoro.x -= velocidade;

        if (posicaoDino.y > posicaoMeteoro.y) posicaoMeteoro.y += velocidade;
        else posicaoMeteoro.y -= velocidade;

        this.transform.position = posicaoMeteoro;
        */

        if (transform.position.y < -14f) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
