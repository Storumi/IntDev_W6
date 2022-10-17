using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jiggle : MonoBehaviour
{
    public float weight = 0.1f;
    public Vector3 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offSet = new Vector3(0f, weight * Mathf.Sin(Time.time*2), 0f);
        transform.position = originalPosition + offSet;
    }
}
