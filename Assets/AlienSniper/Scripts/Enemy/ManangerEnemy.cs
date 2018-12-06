using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManangerEnemy : MonoBehaviour
{
    public GameObject npc;//enemigo a instanciar
    public GameObject [] Enemys;//numero de enemigos en la escena
    public int numEnem;//numero de enemigos que se reponen
    public int totalEnemys;//total enemigos a matar
    public int contadorE;

    void Start()
    {
        numEnem = 10;
        contadorE = numEnem;
        if (Enemys.Length < 10)
        {
            numEnem = 10 - totalEnemys;
            for (int i = 0; i < numEnem; i++)
            {
                GameObject go = Instantiate(npc, new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)), transform.rotation);
            }
        }
    }
    public void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Besaca");
        totalEnemys = Enemys.Length;
    }
    public void Reset()
    {
        Start();
    }
}
