using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Efectobala : MonoBehaviour
{
	public float tiempodevida;
	public GameObject Pref_Explosion;
    public void Destruir()
	{
		Destroy (this.gameObject, tiempodevida); 
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name != null)
		{
            Destroy (this.gameObject);
        }
        if (collision.gameObject.tag == "Besaca")
        {
            GameObject explosion = Instantiate(Pref_Explosion, collision.contacts[0].point, Quaternion.identity);//istancia el efeto de la explosion 
            Destroy(explosion, 0.2f);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Cuerpo")
        {
            GameObject explosion = Instantiate(Pref_Explosion, collision.contacts[0].point, Quaternion.identity);//istancia el efeto de la explosion 
            Destroy(explosion, 0.2f);
            Destroy(this.gameObject);
        }
    }
}