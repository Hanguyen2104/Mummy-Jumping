using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausedialog : MonoBehaviour
{
    public GameObject pauseDialog;
    public void Show()
    {
        pauseDialog.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        pauseDialog.SetActive(false);
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        GameManager.Instance.state = GameState.Starting;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        UIManager.Instance.ShowGamePlay(false);
    }
}
