using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _target;

    public float _camSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, _target.position, _camSpeed * Time.deltaTime);
        newPos.z = -10f;
        transform.position = newPos;
    }
}
