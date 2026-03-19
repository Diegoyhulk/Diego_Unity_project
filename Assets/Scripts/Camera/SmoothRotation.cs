using System;
using UnityEngine;

public class SmoothRotation : MonoBehaviour
{
    [SerializeField] public float mouseSensitivity;
    public Transform playerBody;
    
    //AcumulativeRotation
    float xRot = 0f;
    float yRot = 0f;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        // --Rotacion Vertical1
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -10f, 45f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        
        //--Rotacion Horizontal
        yRot += mouseX;
        yRot = Mathf.Clamp(yRot, -90f, 90f);
        playerBody.localRotation = Quaternion.Euler(0f, yRot, 0f);
    }
}
