using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float Speed { get; set; }

    public void Rotate(Vector3 direction)
    {
        transform.Rotate(direction.normalized * Speed * Time.deltaTime);
    }
}
