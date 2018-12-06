using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collissions : MonoBehaviour
{
    public NPCS npc;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Efectobala>())
        {
            npc.sangrar = true;
            FindObjectOfType<Disparo>().activa = true;
            FindObjectOfType<InterfasUsuario>().m += 1;
            FindObjectOfType<ManangerEnemy>().contadorE -= 1;
            this.gameObject.SetActive(false);
        }
    }
}
