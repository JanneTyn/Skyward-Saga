using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 1.19f; // voi vaihtaa nopeutta unitys
    Vector3 pointA;
    Vector3 pointB;

    void Start()
    {
        pointA = new Vector3(20, 0, 0);
        pointB = new Vector3(50, 0, 0); // x, y, z, mis se ukko liikkuu
    }

    void Update()
    {
       
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}
