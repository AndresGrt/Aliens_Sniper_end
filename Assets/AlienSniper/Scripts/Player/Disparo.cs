using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public int numDisparo;
	public GameObject proyectil;
	public Transform spawnpoint;
	public float force;
	public AudioSource source;
	public AudioClip efectodisparo;
    public ParticleSystem particle;
    public bool activa;
    private void Start ()
	{
        force = 1000f;
        activa = false;
        Atributos();
	}
    private void Update()
    {
        if (activa)
        {
            FindObjectOfType<InterfasUsuario>().HeadShoot();
        }
    }
    public void Atributos()
    {
        source = spawnpoint.GetComponent<AudioSource>();
    }
    
    public void Disparar ()
	{
        numDisparo += 1;
	    GameObject bala = Instantiate(proyectil,transform.position,transform.rotation);
	    bala.GetComponent<Rigidbody> ().AddForce (bala.transform.forward * force, ForceMode.Impulse);
        source.PlayOneShot(efectodisparo);
        bala.GetComponent<Efectobala> ().Destruir ();
        particle.Play(true);
    }

}
 