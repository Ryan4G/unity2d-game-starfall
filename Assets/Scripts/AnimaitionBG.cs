using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimaitionBG : MonoBehaviour
{
    Material material;
        Vector2 movement;

    public Vector2 speed;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        movement += speed * Time.deltaTime;
        material.mainTextureOffset = movement;
    }
}

