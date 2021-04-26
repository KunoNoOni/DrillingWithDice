using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDice : MonoBehaviour
{
    private float rotationSpeed = 2000.0f;
    private bool canRotate = false;
    private float cooldown = .5f;

    void Update()
    {
        if (canRotate)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
            cooldown -= Time.deltaTime;
        }

        if (cooldown <= 0)
        {
            canRotate = false;
            cooldown = .5f;
            ResetDiceRotation();
        }
    }

    public void SetCanRotate(bool value)
    {
        canRotate = value;
    }

    private void ResetDiceRotation()
    {
        transform.rotation = Quaternion.identity;
    }
}
