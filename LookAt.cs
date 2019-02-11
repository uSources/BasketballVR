using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target;

    private void Update()
    {
        transform.LookAt(target.transform);
        Quaternion rot = transform.rotation;

        rot.z = 0;
        rot.x = 0;
        transform.rotation = rot;

    }
}
