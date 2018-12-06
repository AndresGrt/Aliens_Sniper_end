using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    //Llama la escena  Ir_Menu
    public void Go_Menu()
    {
        SceneManager.LoadScene("Scene_Menu");
    }
    //Llama la escena Ir_Instructions
    public void Go_Instructions()
    {
        SceneManager.LoadScene("Scene_Instructions");
    }
    //Llama la escena Ir_Registry
    public void Go_Registry()
    {
        SceneManager.LoadScene("Scene_Menu");
    }
    //Llama la escena Ir_Scoores
    public void Go_Scoores()
    {
        SceneManager.LoadScene("Scene_Scoores");
    }

    public void Go_Game()
    {
        SceneManager.LoadScene("Scene_Game");
    }

    //Sale de la aplicacion
    public void Exit_Game()
    {
        Application.Quit();
    }
}
