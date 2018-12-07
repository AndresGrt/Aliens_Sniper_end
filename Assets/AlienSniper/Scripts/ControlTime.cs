using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTime : MonoBehaviour
{
    
    float s;
    float sT;
    float mT;
    int min;
    int seg;
    [Header("Mananger Time")]
    public int minutos;
    public int segundos;
    public int minTotal;
    public int segTotal;
    [Header("Mananger Aliens")]
    public GameObject[] Enemys;//numero de enemigos en la escena
    public int numEnem;//numero de enemigos que se reponen

    public void Start()
    {
        min = minutos;
        seg = segundos;
        s = segundos;
    }
    private void Update()
    {
        Enemys = GameObject.FindGameObjectsWithTag("Aliens");
        numEnem = Enemys.Length;

        if ((minutos == 0 && segundos == 0) || (numEnem == 0))
        {
            Guarda();
        }
        else
        {
            CorreTime();
        }
    }
    public void CorreTime()
    {
        s -= Time.deltaTime;
        sT += Time.deltaTime;
        if (s <= 0)
        {
            s = 60;
            minutos -= 1;
        }
        if (sT >= 60)
        {
            sT = 0;
            mT += 1;
        }
        segundos = (int)s;
        FindObjectOfType<InterfasUsuario>().TimeRun();
    }
    public void Guarda()
    {
        if ((minutos == 0 && segundos == 0))
        {
            segTotal = seg;
            minTotal = min;
        }
        else
        {
            segTotal = (int)sT;
            minTotal = (int)mT;
        }
        GameOver();
    }
    public void GameOver()
    {
        s = 0;
        minutos = 0;
        FindObjectOfType<InterfasUsuario>().TotalTime();
        FindObjectOfType<InterfasUsuario>().activo = true;
    }
    public void ResetTime()
    {
        s = seg;
        minutos = min;
        sT = 0;
        mT = 0;
        Reset();
        FindObjectOfType<InterfasUsuario>().activo = false;
        FindObjectOfType<ZoomCamera>().Play_Zoom();
        FindObjectOfType<InterfasUsuario>().RecorsGame();
    }
    public void Reset()
    {
        Start();
    }
}