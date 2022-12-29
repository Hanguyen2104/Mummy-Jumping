using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChecking : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(Gametag.Platform.ToString()))
        {
            var platFormCol = col.GetComponent<Platform>();
            if (!platFormCol || !GameManager.Instance || !GameManager.Instance.LastPlatformSpawned) return;
            if(platFormCol.ID == GameManager.Instance.LastPlatformSpawned.ID)
            {
                GameManager.Instance.SpawnPlatform();
            }
        }
    }
}
