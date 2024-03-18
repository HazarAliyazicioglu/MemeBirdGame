using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public event Action dead;
    public event Action scoring;
    public event Action ready;
    public static bool isStarted;
    public AudioClip audioClip;
    
    private AudioSource audioSource;
    private Vector3 direction;
    private int indexNumber;
    private float gravity;
    private float strength = 5f;
    private bool isDead;
    

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isStarted = false;
        isDead = false;
        gravity = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Died();
        
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (ready != null){ready();}
            isStarted = true;
            gravity = -9.8f;
            direction = Vector3.up * strength;
            PlayAudio();
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began){direction = Vector2.up * strength;}
            
        }

        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            isDead = true;
            if (dead != null)
            {
                dead();
            }

            audioSource.clip = audioClip;
            audioSource.Play();

        }

        if (other.gameObject.CompareTag("Scoring"))
        {
            if (scoring != null){ scoring();}
        }
        
    }

    private void Died()
    {
        if (isDead == false)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }   
    }
    
    private void PlayAudio()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }
}
