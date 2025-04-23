using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
   
    private Slider _healthBar;
    private Animator _animator;
    private AudioSource _audioSource;
    private Rigidbody2D _rigidBody;

    public int direction = 1;
    public float speed = 5;
    public AudioClip _deathSFX;
    private BoxCollider2D _boxCollider;

    public GameManager _gameManager;

    public float maxHealth;
    private float currentHealth;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _rigidBody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _healthBar = GetComponentInChildren<Slider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

        currentHealth = maxHealth;
        _healthBar.maxValue = maxHealth;
        _healthBar.value = maxHealth;
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

        _gameManager.AddGombas();

        direction = 0;
        _rigidBody.gravityScale = 0;
        _animator.SetTrigger("IsDeath");
        _boxCollider.enabled = false;
        _audioSource.PlayOneShot(_deathSFX);
        Destroy(gameObject, 2);
    }

    public void TakeDamage(float damage)
    {
        currentHealth-= damage;

        _healthBar.value = currentHealth;

        if(currentHealth <= 0)
        {
            Death();
        }
        
    }

    void OnCollisionEnter2D(Collision2D Collision) 
    {
        if(Collision.gameObject.CompareTag("Tuberia") || Collision.gameObject.layer == 6 || Collision.gameObject.layer == 8)
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
        direction = 1;
        _gameManager.enemiesInScreen.Add(gameObject);
    }
    private void OnBecameInvisible()
    {
        direction = 0;
        _gameManager.enemiesInScreen.Remove(gameObject);
    }
}
