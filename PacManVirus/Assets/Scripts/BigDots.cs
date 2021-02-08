using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDots : MonoBehaviour
{
    //public GameObject ghost1;
    //protected override void collected(Collider2D coll)
    //{
      //  GameManager.makeGhostsVulnerable();
       // base.collected(coll);
    //}

    public int points = 50;

    public Ghosts[] ghosts = new Ghosts[4];

    public Ghosts ghost1;
    public Ghosts ghost2;
    public Ghosts ghost3;
    public Ghosts ghost4;

    public AudioClip collectedClip;

    //Ghosts ghost = other.GetComponent<Ghosts>();
    //Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i < 4; i++)
        {
            ghosts[i] = gameObject.GetComponent<Ghosts>();
        }
        //ghosts[i] = theNewObject.GetComponent<ghosts>();

        //ghosts = gameObject.GetComponents<ghosts>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PacManController controller = other.GetComponent<PacManController>();

        if (other.gameObject.tag == "Player")
        {
            controller.addPoints(points);
            controller.removedot();
            gameObject.SetActive(false);
            // controller.canEat = true;
            //for (int i = 0; i < 4; i++)
            //{
             //   ghosts[i].setVulnerable(true); // = gameObject.GetComponent<Ghosts>();
            //}

            //foreach (Ghosts ghost in ghosts)
            //{
            //    ghost.setVulnerable(true);
            //}
            //ghost.setVulnerable(true);
            ghost1.setVulnerable(true);
            ghost2.setVulnerable(true);
            ghost3.setVulnerable(true);
            ghost4.setVulnerable(true);

            controller.PlaySound(collectedClip);
        }
    }
}
