using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private Camera mainCam;

    private string capturePath = "ScreenShot";

    private void Awake()
    {
        mainCam = Camera.main;
    }

    private void OnZoom(InputValue value)
    {
        float yAxis = value.Get<Vector2>().y;

        if (yAxis >= 120)
            mainCam.fieldOfView += 10;
        else if(yAxis <= -120)
            mainCam.fieldOfView -= 10;
    }

    private void OnCapture(InputValue value)
    {
        ScreenCapture.CaptureScreenshot($"Assets/ScreenShot/ScreenCapture.png");
    }
}