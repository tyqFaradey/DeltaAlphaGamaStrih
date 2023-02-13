using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject game, gameOver;

    void Start()
    {
        game.SetActive(true);
        gameOver.SetActive(false);
    }

    public void GameOver()
    {
        game.SetActive(false);
        gameOver.SetActive(true);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
