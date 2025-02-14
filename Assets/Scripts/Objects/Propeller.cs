using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Propeller : MonoBehaviour
{
    public bool isOn = false;
    [SerializeField] private float rotationSpeed = 20;

    void Update()
    {
        if (isOn)
        {
            PropellerRotate();
        }
    }

    public void PropellerRotate()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
    }
}
