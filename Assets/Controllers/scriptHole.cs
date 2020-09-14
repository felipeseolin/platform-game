using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptHole : MonoBehaviour
{
    public LayerMask pcLayerMask;
    public Animator pcAnimator;

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

        if (hit2D.collider != null)
        {
            this.pcAnimator.SetBool(Animator.StringToHash("IsDead"), true);
            Time.timeScale = 0;
        }
    }
}
