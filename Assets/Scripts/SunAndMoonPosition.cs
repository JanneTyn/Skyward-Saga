using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoonPosition : MonoBehaviour
{
    [SerializeField] Transform posX;

    private void Update()
    {
        transform.position = new Vector3(posX.position.x, transform.position.y, transform.position.z);
    }
}
