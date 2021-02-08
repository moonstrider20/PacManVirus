using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleDots : MonoBehaviour
{
    public AudioClip collectedClip;
    public int points = 10;

    void OnTriggerEnter2D(Collider2D other)
    {
        PacManController controller = other.GetComponent<PacManController>();

        if (other.gameObject.tag == "Player")
        {
            controller.addPoints(points);
            controller.removedot();
            controller.PlaySound(collectedClip);
            gameObject.SetActive(false);
        }
    }
}