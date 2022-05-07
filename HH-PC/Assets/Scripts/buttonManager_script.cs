using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class buttonManager_script : MonoBehaviour
{

    public void Reiniciar()
    {
        GameObject gm = FindObjectOfType<GameManager_Script>().gameObject;
        gm.GetComponent<GameManager_Script>().pause = false;
        SceneManager.LoadScene("SampleScene");
    }

    public void Continuar()
    {
        GameObject gm = FindObjectOfType<GameManager_Script>().gameObject;
        gm.GetComponent<GameManager_Script>().pause = false;
    }

    public void SalirMenu()
    {
        GameObject gm = FindObjectOfType<GameManager_Script>().gameObject;
        gm.GetComponent<GameManager_Script>().pause = false;
        SceneManager.LoadScene("Menu");
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Game()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Manual()
    {
        SceneManager.LoadScene("Info");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }


}
