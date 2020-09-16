using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGame : MonoBehaviour
{
    public static bool PcIsDead = false;
    public Animator pcAnimator;
    public GameObject gameOverUI;

    private AudioSource _stageSound;

    // Start is called before the first frame update
    void Start()
    {
        PcIsDead = false;
        Time.timeScale = 1f;
        _stageSound = GetComponent<AudioSource>();
        _stageSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.GameOver();
    }

    public void GameOver()
    {
        if (PcIsDead)
        {
            Time.timeScale = 0;
            _stageSound.Stop();
            gameOverUI.SetActive(true);
        }
        else
        {
            gameOverUI.SetActive(false);
        }
    }
}
