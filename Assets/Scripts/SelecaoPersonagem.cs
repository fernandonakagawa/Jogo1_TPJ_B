using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelecaoPersonagem : MonoBehaviour
{
    private GameObject personagem;
    void Start()
    {
        
        int codigoPersonagem = PlayerPrefs.GetInt("personagem");
        if(codigoPersonagem == 0)
        {
            personagem = Instantiate(Resources.Load("Prefabs/Dino")) as GameObject;
        }
        else if(codigoPersonagem == 1)
        {
            personagem = Instantiate(Resources.Load("Prefabs/p2")) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicaoPersonagem = personagem.transform.position;
        posicaoPersonagem.x += 3f;
        posicaoPersonagem.y += 1f;
        posicaoPersonagem.z = -10f;
        this.transform.position = posicaoPersonagem;
    }

    //public void 

}
