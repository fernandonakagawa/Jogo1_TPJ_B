using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteoro : MonoBehaviour
{
    public GameObject dino;
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicaoDino = dino.transform.position;
        Vector3 posicaoMeteoro = this.transform.position;
        if (posicaoDino.x > posicaoMeteoro.x) posicaoMeteoro.x += velocidade;
        else posicaoMeteoro.x -= velocidade;

        if (posicaoDino.y > posicaoMeteoro.y) posicaoMeteoro.y += velocidade;
        else posicaoMeteoro.y -= velocidade;

        this.transform.position = posicaoMeteoro;
    }
}
