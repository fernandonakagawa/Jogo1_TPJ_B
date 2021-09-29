using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrocarPersonagem : MonoBehaviour
{
    public void EscolherPersonagem(int personagem)
    {
        PlayerPrefs.SetInt("personagem", personagem);
        SceneManager.LoadScene("SampleScene");
    }
}
