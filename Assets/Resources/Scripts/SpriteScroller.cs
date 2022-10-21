using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] private Vector2 moveSpeed;

    private Vector2 offset;
    private Material backgroundMaterial;

    void Awake()
    {
        backgroundMaterial = GetComponent<SpriteRenderer>().material;
    }
    
    void Update()
    {
        //Makes the move speed framerate independent
        offset = moveSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
    }
}
