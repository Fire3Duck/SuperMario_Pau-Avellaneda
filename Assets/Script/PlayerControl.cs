using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float playerSpeed = 4.5f;
    public int direction = 1;

    private float inputHorizontal; 
    
    public Rigidbody2D rigidBody;
    private GroundSensor _groundSensor;
    private SpriteRenderer _spriteRender;
    public float jumpForce = 10;

    private Animator _animator;

    private AudioSource _audioSource;
    private BoxCollider2D _boxCollider;
    private GameManager _gameManager;
    private SoundManager _soundManager;

    public AudioClip jumpSFX;
    public AudioClip deathSFX;
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        _groundSensor = GetComponentInChildren<GroundSensor>();
        _spriteRender = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Esto es para teletransporte
        //transform.position = new Vector3(-91, -1, 0); //Cuando son numeros con decimales se añade un punto en vez de coma y poner una f
    }

    // Update is called once per frame
    void Update() //para los botones 
    {
        if(!_gameManager.isPlaying)
        {
            return;
        }

        if(_gameManager._isPaused)
        {
            return;
        }
    
        inputHorizontal = Input.GetAxisRaw("Horizontal"); //Aqui hacemos que el personaje se mueva cuando pulsamos un boton.

        if(Input.GetButtonDown("Jump") && _groundSensor.isGrounded == true) //GetButton tiene 3 formas (El Down que hace la accion cuando pulsa el boton, el Up que hace la acicon cuando sueltas el boton y el GetButton que hace manteniendo el boton)
        {
            Jump();
        }

      Movement();

    _animator.SetBool("IsJumping", !_groundSensor.isGrounded);

      /*if(_groundSensor.isGrounded)
      {
        _animator.SetBool("IsJumping", false);
      }*/

        //transform.position = new Vector3(transform.position.x + direction * playerSpeed * Time.deltaTime, transform.position.y, transform.position.z) ;
        //transform.Translate(new Vector3(direction * playerSpeed * Time.deltaTime, 0, 0));
        //transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x + inputHorizontal, transform.position.y), playerSpeed * Time.deltaTime);
    }

    void FixedUpdate() //formas de avanzar de derecha a izquierda
    {
        rigidBody.velocity = new Vector2(inputHorizontal * playerSpeed, rigidBody.velocity.y);
        //rigidBody.AddForce(new Vector2(inputHorizontal, 0));
        //rigidBody.MovePosition(new Vector2(100, 0));
    }

    void Movement ()
    {
        if(inputHorizontal > 0)
        {
            _spriteRender.flipX = false;
            _animator.SetBool("IsRunning", true);
        }
        else if(inputHorizontal < 0)
        {
            _spriteRender.flipX = true;
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning", false);
        }
    }

    void Jump()
    {
    rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //hacer que salte
    _animator.SetBool("IsJumping", true);
    _audioSource.PlayOneShot(jumpSFX);
    }

    public void Death()
    {
        _animator.SetTrigger("IsDead");
        _audioSource.PlayOneShot(deathSFX);
        _boxCollider.enabled = false;

        Destroy(_groundSensor.gameObject);
        inputHorizontal = 0;
        rigidBody.velocity = Vector2.zero;
        
        rigidBody.AddForce(Vector2.up * jumpForce / 2, ForceMode2D.Impulse);
        
        _gameManager.isPlaying = false;

        

        StartCoroutine(_soundManager.DeathBGM());
        //_soundManager.StartCoroutine("DeathBGM");

        //_soundManager.Invoke("DeathBGM", deathSFX.lenght);

        
    }
}