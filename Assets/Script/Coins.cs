using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    
    private AudioSource _audioSource;
    public AudioClip CoinSFX;
    private SpriteRenderer _renderer;

    void Awake()
    
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void OnCollisionEnter2D(Collision2D Collision) 
    {
        if(Collision.gameObject.CompareTag("Player"))
        {
            //Destroy(Collision.gameObject);
            PlayerControl playerScript = Collision.gameObject.GetComponent<PlayerControl>();
            Death();
        }
    }

    public void Death()
    {
        _boxCollider.enabled = false;
        _renderer.enabled = false;
        _audioSource.PlayOneShot(CoinSFX);
        Destroy(gameObject, 0.8f);
    }
}
