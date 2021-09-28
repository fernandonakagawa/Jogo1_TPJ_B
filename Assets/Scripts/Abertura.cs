using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Abertura : MonoBehaviour
{
    //public AudioClip musica;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        float la = Soma(2, 3);
        Debug.Log(la);
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    private float Soma(float n1, float n2)
    {
        float resposta = n1 + n2;
        return resposta;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar()
    {
        SceneManager.LoadScene("SelecaoPersonagem");
    }
}
