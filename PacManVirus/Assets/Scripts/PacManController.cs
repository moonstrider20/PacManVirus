//Amorina Tabera
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PacManController : MonoBehaviour
{

    public float speed;
    private int scoreValue = 0;
    public int livesLeft = 3;
    public int lifescore = 0;
    public Text score;

    public GameObject life1, life2, life3, life4, life5;

    // public bool canEat = false;

    private Vector2 direction;          //direction pacman is going
    private bool alive = true;
    private int dots = 244;
    private static bool level = false;
    private Vector2 originalPosition;

    Rigidbody2D rb2d;
    float horizontal;
    float vertical;

    Animator animator;
    Vector2 lookDirection = new Vector2(0.5f, 0);

    AudioSource audioSource;

    public AudioClip bgMusic;
    public AudioSource musicSource;
    public AudioSource soundSource;

    //Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + scoreValue.ToString();

        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalPosition = transform.position;

        audioSource = GetComponent<AudioSource>();

        //Music
        musicSource.clip = bgMusic;
        //soundSource.clip = munch;
        musicSource.Play();

        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(false);
        life1.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //ANIMATION
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        checklives();

    }

    //Call potentially more than once per frame
    void FixedUpdate()
    {
        if (alive)
        {
            //to move the player
            if (Input.GetAxis("Horizontal") < 0)
            {
                direction = Vector2.left;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                direction = Vector2.right;
            }
            if (Input.GetAxis("Vertical") < 0)
            {
                direction = Vector2.down;
            }
            if (Input.GetAxis("Vertical") > 0)
            {
                direction = Vector2.up;
            }

            //Keeps pacman moving
            rb2d.velocity = direction * speed;

            //SIMPLE grid movment
            if (rb2d.velocity.x == 0)
            {
                transform.position = new Vector2(Mathf.Round(transform.position.x), transform.position.y);
            }
            if (rb2d.velocity.y == 0)
            {
                transform.position = new Vector2(transform.position.x, Mathf.Round(transform.position.y));
            }

        }

        //ESC
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (dots == 0)
        {
            NextLevel();
        }
    }

    public void addPoints(int pointsToAdd)
    {
        scoreValue += pointsToAdd;
        SetScoreText();

        if (scoreValue - lifescore > 50000 )
        {
            lifescore = lifescore + 5000;
            livesLeft++;
        }
       // scoreText.text = "" + score;
    }

    public void removedot()
    {
        --dots;
    }

    public void setAlive(bool isAlive)
    {
        alive = isAlive;
        animator.SetBool("alive", alive);
        rb2d.velocity = Vector2.zero;
    }

    public void setLivesLeft(int lives)
    {
        livesLeft = lives;
        //life1.enabled = livesLeft >= 1;
        //life2.enabled = livesLeft >= 2;
    }

    public void NextLevel()
    {
        if (!level)
        {
            level = true;
            SceneManager.LoadScene("LevelTwo");
        }

        else
        {
            level = false;
            SceneManager.LoadScene("Winner");
        }
    }

    public void die()
    {
        --livesLeft;
        gameover();
        transform.position = originalPosition;
    }

    public void gameover()
    {
        if (livesLeft == 0)
        {
            SceneManager.LoadScene("Loser");
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void SetScoreText()
    {
        score.text = "Score: " + scoreValue.ToString();
    }

    void checklives()
    {
        switch (livesLeft)
        {
            case 5:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(true);
                break;
            case 4:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(true);
                life5.gameObject.SetActive(false);
                break;
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                life4.gameObject.SetActive(false);
                life5.gameObject.SetActive(false);
                break;
        }
    }

}