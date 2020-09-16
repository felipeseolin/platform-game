using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptHole : MonoBehaviour
{
    public LayerMask pcLayerMask;
    public Animator pcAnimator;
    public AudioSource pcDeadSound;

    private float _width;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        
        _width = height * cam.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right, _width * 10, pcLayerMask);

        if (!scriptGame.PcIsDead && hit2D.collider)
        {
            scriptGame.PcIsDead = true;
            this.pcAnimator.SetBool(Animator.StringToHash("IsDead"), true);
            Time.timeScale = 0;
            this.pcDeadSound.Play();
        }
    }
}
