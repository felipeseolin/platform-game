using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGame : MonoBehaviour
{
    public static bool PcIsDead = false;
    public static bool PcWon = false;
    public Animator pcAnimator;
    public GameObject gameOverUI;
    public GameObject wonUI;

    private AudioSource[] _sounds;
    private AudioSource _stageSound;
    private AudioSource _winSound;
    private bool _showingPanel = false;

    // Start is called before the first frame update
    void Start()
    {
        PcIsDead = false;
        PcWon = false;
        _showingPanel = false;
        Time.timeScale = 1f;
        _sounds = GetComponents<AudioSource>();
        _stageSound = _sounds[0];
        _winSound = _sounds[1];
        _stageSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.GameOver();
        this.GameWon();
    }

    public void GameOver()
    {
        if (_showingPanel)
            return;
        
        if (PcIsDead)
        {
            Time.timeScale = 0;
            _stageSound.Stop();
            gameOverUI.SetActive(true);
            _showingPanel = true;
        }
        else
        {
            gameOverUI.SetActive(false);
        }
    }
    
    public void GameWon()
    {
        if (_showingPanel)
            return;
        
        if (PcWon)
        {
            Time.timeScale = 0;
            wonUI.SetActive(true);
            _stageSound.Pause();
            _stageSound.Stop();
            _winSound.Play();
            _showingPanel = true;
        }
        else
        {
            wonUI.SetActive(false);
        }
    }
}
