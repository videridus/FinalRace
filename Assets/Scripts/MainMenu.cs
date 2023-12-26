using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene("Game");// в кавычках название сцены на которую осуществляется переход
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Game-1");// в кавычках название сцены на которую осуществляется переход
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Game-2");// в кавычках название сцены на которую осуществляется переход
    }

    public void LoadCoop()
    {
        SceneManager.LoadScene("Game with friend");// в кавычках название сцены на которую осуществляется переход
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");// в кавычках название сцены на которую осуществляется переход
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
