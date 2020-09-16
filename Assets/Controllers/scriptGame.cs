using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scriptGame : MonoBehaviour
{
    public Animator pcAnimator;
    
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
        this.GameOver();
    }

    private void GameOver()
    {
        bool isDead = this.pcAnimator.GetBool(Animator.StringToHash("IsDead"));
        if (isDead)
        {
            Time.timeScale = 0;
            _stageSound.Stop();
        }
    }
}
