using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag(Gametag.Player.ToString()))
        {
            Destroy(collision.gameObject);
            if(GameManager.Instance)
            {
                GameManager.Instance.state = GameState.Gameover;
            }
            if(AudioController.Instance)
            {
                AudioController.Instance.PlaySound(AudioController.Instance.gameover);
            }
            if(UIManager.Instance && UIManager.Instance.gameoverDialog)
            {
                UIManager.Instance.gameoverDialog.Show(true);
            }
            
        }

        if(collision.CompareTag(Gametag.Platform.ToString()))
        {
            Destroy(collision.gameObject);
        }
    }
}
