using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling : MonoBehaviour
{
    [SerializeField]
    private float scollX = 0.5f, scollY = 0.5f;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        float offsetX = Time.time * scollX;
        float offsetY = Time.time * scollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
