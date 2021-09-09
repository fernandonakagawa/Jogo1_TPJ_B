using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuvaMeteoros : MonoBehaviour
{
    public GameObject meteoroPrefab;
    public GameObject dino;
    public float meteoroTempo;
    private float meteoroTempoAtual;
    void Start()
    {
        meteoroTempoAtual = meteoroTempo;
    }

    // Update is called once per frame
    void Update()
    {
        meteoroTempoAtual -= Time.deltaTime;
        if(meteoroTempoAtual <= 0)
        {
            Vector3 meteoroPos = dino.transform.position;
            meteoroPos.y += 10f;
            meteoroPos.x += Random.Range(-1, 25);
            //Debug.Log(Random.Range(24, 66));
            Instantiate(meteoroPrefab, meteoroPos, dino.transform.rotation);
            meteoroTempoAtual = meteoroTempo;
        }
        //Random rand = 
    }
}
