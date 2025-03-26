using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   

    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidBody;

    public int direction = 1;
    public float speed = 5;
    public AudioClip _deathSFX;
    private BoxCollider2D _boxCollider;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
    }

    public void Death()
    {
        direction = 0;
        _rigidBody.gravityScale = 0;
        _animator.SetTrigger("IsDeath");
        _boxCollider.enabled = false;
        Destroy(gameObject, 0.3f);
    }

    void OnCollisionEnter2D(Collision2D Collision) 
    {
        if(Collision.gameObject.CompareTag("Tuberia") || Collision.gameObject.layer == 6)
        {
          direction *= -1;  
        }
        
        if(Collision.gameObject.CompareTag("Player"))
        {
            //Destroy(Collision.gameObject);
            PlayerControl playerScript = Collision.gameObject.GetComponent<PlayerControl>();
            playerScript.Death();
        }
    }

    private void OnBecameVisible()
    {
        speed = 5;
    }
    private void OnBecameInvisible()
    {
        speed = 0;
    }
}
