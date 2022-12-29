using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameoverDialog : MonoBehaviour
{
    public GameObject gameoverDialog;
    public Text totalScoreTxt;
    public Text bestScoreTxt;

    public void Start()
    {
        
    }

    public void Show(bool isShow)
    {
        gameoverDialog.SetActive(isShow);
        if(totalScoreTxt && GameManager.Instance)
        {
            totalScoreTxt.text = GameManager.Instance.Score.ToString();
        }
        if (bestScoreTxt && GameManager.Instance)
        {
            bestScoreTxt.text = Pref.bestScore.ToString();
        }
    }

    public void RePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if(GameManager.Instance)
        {
            GameManager.Instance.PlayGame();
        }
        UIManager.Instance.ShowGamePlay(true);

    }
}
