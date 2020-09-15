using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptCamera : MonoBehaviour
{
    public GameObject pc;
    public float offsetY = 4;
    public float offsetX = 4;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = new Vector3(
            pc.transform.position.x + offsetX,
            pc.transform.position.y + offsetY,
            -10
        );
        this.transform.position = position;
    }
}