using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCircAnim : MonoBehaviour
{
    float timer = 0;
    public float width;
    public float radius;
    public float speed = 3;
    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        
    }


    void Update()
    {
        timer += Time.deltaTime * speed;
        timer -= Time.deltaTime;
        float x =  Mathf.Cos(timer)*width;
        float z =  Mathf.Sin(timer) *radius;

        transform.position = new Vector3(x, 0f, z) + startPos;
    }
}
