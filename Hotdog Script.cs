using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotdogScript : MonoBehaviour
{
     public float rotateSpeed;

    private void FixedUpdate () {
        transform.Rotate(0, 0, rotateSpeed);
    }
}
