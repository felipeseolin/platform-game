using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGame : MonoBehaviour
{
    private bool _isPaused = false;

    private AudioSource _stageSound;
    // Start is called before the first frame update
    void Start()
    {
        _stageSound = GetComponent<AudioSource>();
        _stageSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        this.Pause();
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                _isPaused = false;
                Time.timeScale = 1;
                _stageSound.Play();
                SceneManager.UnloadSceneAsync(0);
            }
            else
            {
                _isPaused = true;
                Time.timeScale = 0;
                _stageSound.Pause();
                SceneManager.LoadSceneAsync(0, LoadSceneMode.Additive);
            }
        }
    }
}
