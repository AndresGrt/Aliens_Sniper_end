using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour {
		public bool attacking = false;
        bool enemmy = false;
        public float vida;
	// Use this for initialization
	void Start () {
		attacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Disminuir_Vida(float dano)
	{
		vida = vida - dano;
	}
}
