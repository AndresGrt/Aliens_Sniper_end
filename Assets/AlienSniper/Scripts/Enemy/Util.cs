using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour 
{


	float timer = 0;
    int i = 0;
    int otro = 0;
    public GameObject[] enemy_group;
    public GameObject[] ally_group;
    public Vector3[] posicion_entrada;

    public int cant_posiciones;
    public int cant_ally;

    public Vector3 posicion_inicial;
    public float posicion_x;
    public float posicion_z;
    public float posicion_y;

    public int asignacion;
    public int cantidad_tropa;

    public bool tropa = false;

	// Use this for initialization
	void Start () 
	{
		cant_ally = 5;
        ally_group = new GameObject[cant_ally];
        Load_Ally();


        posicion_inicial = new Vector3(-136, 0.1f, 48);
        posicion_x = posicion_inicial.x;
        posicion_y = 2;
        posicion_z = posicion_inicial.z;
        cant_posiciones = 10;
        posicion_entrada = new Vector3[cant_posiciones];

        Cargar_posiciones();
        asignacion = 0;

        enemy_group = new GameObject[cant_posiciones];

	}
	
	// Update is called once per frame
	void Update () 
	{

		if(!tropa)
        {          
            timer += Time.deltaTime;          
            while (i<cant_posiciones && timer > 2.5f)
            {               
                timer = 0;
                i++;
                Create_();
            }
            
            if (i >=cant_posiciones)
            {
                tropa = true;
            }
            if (enemy_group[cant_posiciones -1] != null)
            {
                int a = enemy_group[cant_posiciones -1].GetComponent<Enemy>().Retorna_estado();
                if(a ==3)
                {
                    tropa = true;
                }
               
            }    
        }

		
	}



    public void Cargar_posiciones()
    {
        for (int i = 0; i < cant_posiciones; i++)
        {
            if (i < 5)
            {
                posicion_entrada[i] = new Vector3(posicion_x, posicion_y, posicion_z);
                posicion_x += 2.5f;
                posicion_z += 2.5f;
            }
            else
            {
                posicion_entrada[i] = new Vector3(posicion_x+225f, posicion_y, posicion_z-37);
                posicion_x += 2.5f;
            }
        }
    }


	public Vector3 Asignar_posicion()
    {
        Vector3 posicion;
        posicion = posicion_entrada[asignacion];
        asignacion++;
        return posicion;

    }


	   public void Create_()
    {  	
            GameObject enemy = Instantiate(Resources.Load("Cube") as GameObject, transform.position, transform.rotation);
            enemy_group[otro] = enemy;
            otro++;	
    }



    public void Load_Ally()
    {
        for (int j =0;j< cant_ally;j++)
        {
            string names = "Ally" + j;
            GameObject Ally = Instantiate(Resources.Load("Soldier") as GameObject, transform.position, transform.rotation);
            Ally.transform.position = Asiisgar_psocion_aleatoria();
            ally_group[j] = Ally;
            Ally.name = names;
        }
    }

    public Vector3 Asiisgar_psocion_aleatoria()
    {
    	Vector3 pos = new Vector3();
    	pos.x = Random.Range(-120,120);
    	pos.z = Random.Range(-100,-50);
    	return pos;
    }

    public Vector3 Asignar_Objetivo()
    {
    	Vector3 posocion = new Vector3(0, 0, 0);
  		int pos = Random.Range(0,cant_ally);
        return ally_group[pos].transform.position;
    }
  

}