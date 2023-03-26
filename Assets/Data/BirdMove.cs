using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMove : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject obj;
    private Rigidbody2D m_rb;
    private float flyUp;
    public GameObject gameController;

    public AudioClip flyAudio;
    public AudioClip audioGameOver;
    public AudioClip audioPoint;
    private AudioSource audioSource;
    private Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isDie", false);
        anim.SetFloat("flyPower", 0);
        obj = gameObject;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = flyAudio;

        flyUp = 5;

        m_rb = GetComponent<Rigidbody2D>();

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("gameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
       
            
            if (!gameController.GetComponent<GameController>().isOverGame)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    audioSource.clip = flyAudio;
                    audioSource.Play();
                    m_rb.velocity = new Vector2(0, flyUp);
                }

                anim.SetFloat("flyPower", m_rb.velocity.y);
            }

       
       

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe") || col.gameObject.CompareTag("Base"))
        {
            anim.SetBool("isDie", true);
           
            this.EndGame();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gap"))
        {
            audioSource.clip = audioPoint;
            audioSource.Play();
            gameController.GetComponent<GameController>().GamePoint();
        }
    }
    void EndGame()
    {
        
        audioSource.clip = audioGameOver;
        audioSource.Play();
        gameController.GetComponent<GameController>().GameOver();
    }
}