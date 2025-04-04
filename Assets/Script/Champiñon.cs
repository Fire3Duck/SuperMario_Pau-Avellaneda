using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champiñon : MonoBehaviour
{
    public int direction = 1;

    public float speed = 3;

    private Rigidbody2D _rigidBody;
    private BoxCollider2D _boxCollider;
    
    private AudioSource _audioSource;
    public AudioClip powerUpSFX;
    private SpriteRenderer _renderer;

    void Awake()
    
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        speed = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(direction * speed, _rigidBody.velocity.y);
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
            playerScript.canShoot = true;
            playerScript.powerUpTimer = 0;
            Death();
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

    public void Death()
    {
        direction = 0;
        _rigidBody.gravityScale = 0;
        _boxCollider.enabled = false;
        _renderer.enabled = false;
        _audioSource.PlayOneShot(powerUpSFX);
        Destroy(gameObject, 0.8f);
    }
}
