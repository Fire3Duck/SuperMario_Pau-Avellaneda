using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    private GameManager _gameManager;

    public AudioClip bgm;
    public AudioClip gameOver;

    public float delay = 2;
    public float timer;
    private bool timerFinished = false;

    private Bandera _bandera;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
        _bandera = FindObjectOfType<Bandera>().GetComponent<Bandera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlayBGM();
    }

    // Update is called once per frame
    void Update()
    {
        /*if(!_gameManager.isPlaying && !timerFinished)
        {
             DeathBGM(); 
        }*/
        
    }

    void PlayBGM()
    {
        _audioSource.clip = bgm;
        _audioSource.loop = true;
        _audioSource.Play();
    }


    public void VictoryBGM()
    {
        if(_bandera.Victory)
        {
            _audioSource.Stop();
        }
    }
    public void PauseBGM()
    {
        if(_gameManager._isPaused)
        {
            _audioSource.Pause();
        }
        
        else
        {
            _audioSource.Play();
        }
    }
    

   /* public void DeathBGM()
    {
        _audioSource.Stop();

        timer += Time.deltaTime;

        if(timer >= delay)
        {
            timerFinished = true;
            _audioSource.PlayOneShot(gameOver);
        }
    }*/

    public IEnumerator DeathBGM()
    {
        _audioSource.Stop();

        yield return new WaitForSeconds(delay);
        
        _audioSource.PlayOneShot(gameOver);
    }
}
