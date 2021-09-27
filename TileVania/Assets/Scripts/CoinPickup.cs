using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] AudioClip coinPickupSFX;
    [Range(0.1f, 1f)] [SerializeField] float audioVolume = 0.5f;
    [SerializeField] int coinPickupPoints = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position, audioVolume); // Distortion bug due to Cinamachine Brain.
        AudioSource.PlayClipAtPoint(coinPickupSFX, gameObject.transform.position, audioVolume);
        FindObjectOfType<GameManager>().AddToScore(coinPickupPoints);
        Destroy(gameObject);
    }
}
