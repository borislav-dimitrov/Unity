using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxEffectSpeed; // 0 = move with cam | 1 = won't move | 0.5 = half speed

    void Awake()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * parallaxEffectSpeed;
        float movement = cam.transform.position.x * (1 - parallaxEffectSpeed);

        // Parallax
        transform.position = new Vector3(
            startPos + distance, cam.transform.position.y + 2, transform.position.z
        );

        // Infinitie scrolling
        if (movement > startPos + length) startPos += length;
        else if (movement < startPos - length) startPos -= length;
    }
}
