using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    [SerializeField] GameObject OverUI;
    public bool Item =false;
    public static GamePlay instance;
    public bool finished = false;

    private void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        if(Time.timeScale == 1)
        {
            Player.instance.Anime.enabled = true;
        }
        else
        {

            Player.instance.Anime.enabled = false;
        }
    }
    public void getItem()
    {
        Item = true;
    }
    public void gameOver()
    {
        OverUI.SetActive(true);
        Time.timeScale = 0;

    }
    public void ResetLavel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Exit()
    {

        Audiomanager.instance.playGui();
        SceneManager.LoadScene("Menu");
    }
}
