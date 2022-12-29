using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    public GameObject mainMenu;
    public GameObject gamePlay;
    public Text scoreText;
    public Pausedialog pauseDialog;
    public GameoverDialog gameoverDialog;

    private void Awake()
    {
        if (Instance)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
    }
    public void ShowGamePlay(bool isShow)
    {
        if(gamePlay)
        {
            gamePlay.SetActive(isShow);
        }
        if(mainMenu)
        {
            mainMenu.SetActive(!isShow);
        }
    }
    
    public void updateScore(int score)
    {
         if(scoreText)
        {
            scoreText.text ="Score: " + score.ToString();
        }
    }
}
