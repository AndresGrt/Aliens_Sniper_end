using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public bool attack;
    public Vector3 Posicion_destino;
    public int estado;
    public float Vida;
    public float Dano;
	public Animator enemyAnimator;
	// Use this for initialization
	void Start () 
	{	
       estado = 0;
       //Posicion_destino = FindObjectOfType<Util>().Asignar_posicion();
	   
	}
	



	// Update is called once per frame
	void Update () 
	{
		 if (estado == 0)
        {            
			if(Ir_destino())
			{
				estado =1;
			}          
        }

        if (estado == 1 && attack == false)
        {
        	attack = true;
        	estado = 3;
        	Posicion_destino = FindObjectOfType<Util>().Asignar_Objetivo();
        }

        if(FindObjectOfType<Util>().tropa == true && estado == 3)
        {
        	transform.LookAt(Posicion_destino);
            if ((Posicion_destino - transform.position).magnitude > 1)
            {
                transform.position += transform.forward * (Time.deltaTime * 10);
            }
			
            else
            {				
            	estado =4;
            }
        }

	
	}
	public int Retorna_estado()
	{
		int a;
		a =estado;
		return a;
	}


	public void Disminuir_Vida(float dano_ally)
	{
		Vida = Vida - dano_ally;
	}

	void OnCollisionEnter(Collision collision)
	{
		print("Hola");
		if (collision.gameObject.transform.tag == "Ally")
			{
				Disminuir_Vida(10);
				collision.gameObject.GetComponent<Ally>().Disminuir_Vida(10f);
			}
	}


	public bool Ir_destino()
	{
		bool llegar;
		transform.LookAt(Posicion_destino);
		   if ((Posicion_destino - transform.position).magnitude > 1)
            {					
                	transform.position += transform.forward * (Time.deltaTime * 10);
					llegar = false;
            }
			else
			{
				enemyAnimator.SetBool("adelante",false);
				llegar = true;
			}
	return llegar;
	}

}
