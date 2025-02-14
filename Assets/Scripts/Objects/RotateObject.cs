using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 20;

    private void Update()
    {
        transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
