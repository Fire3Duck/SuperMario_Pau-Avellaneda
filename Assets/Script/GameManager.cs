using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isPlaying = true;
    public bool _isPaused = false;
    private SoundManager _soundManager;

    public GameObject pauseCanvas;
    public Text coinsText;

    private int coins = 0; 

    public Text goombaText;

    private int goombas = 0;

    public List<GameObject> enemiesInScreen;

    void Awake()
    {
        _soundManager = FindObjectOfType<SoundManager>().GetComponent<SoundManager>();
    }

    void Start()
    {
        coinsText.text = "Coins: " + coins.ToString();
        goombaText.text = "Goombas: " + goombas.ToString();
    }
    void Update()
    {
        if(Input.GetButtonDown("Pause"))
        {
            Pause();
        }

        if(Input.GetKeyDown(KeyCode.N))
        {
            foreach(GameObject enemy in enemiesInScreen)
            {
                Enemy enemyScript = enemy.GetComponent<Enemy>();
                enemyScript.Death();
            }
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        if(_isPaused)
            {
                Time.timeScale = 1;
                _isPaused = false;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(false);
            }
            
            else
            {
                Time.timeScale = 0;
                _isPaused = true;
                _soundManager.PauseBGM();
                pauseCanvas.SetActive(true);
            }
    }

    public void AddCoins()
    {
        coins++;
        coinsText.text = "Coins: " + coins.ToString();
        //para que cuente monedas de uno en uno.
    } 

    public void AddGombas()
    {
        goombas++;
        goombaText.text = "Goombas: " + goombas.ToString();
    }
}
