using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecking : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!col.gameObject.CompareTag(Gametag.Platform.ToString())) return;
        var platformlanded = col.gameObject.GetComponent<Platform>();
        if (!GameManager.Instance || !GameManager.Instance.player) return;
        GameManager.Instance.player.Platform = platformlanded;
        GameManager.Instance.player.Jump();
        if(!GameManager.Instance.IsPlatformLanded(platformlanded.ID))
        {
            int randScore= Random.Range(3,8);
            GameManager.Instance.AddScore(randScore);
            GameManager.Instance.PlatformLandIds.Add(platformlanded.ID);
        }
    }
}
