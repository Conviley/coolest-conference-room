using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour {

    private WebCamTexture backCam;

    public Renderer display;

    private void Start() {

        WebCamDevice[] devices = WebCamTexture.devices;

        if (devices.Length == 0) {
            Debug.Log("No device camera detected");
            return;
        }

        for (int i = 0; i < devices.Length; i++) {
            if (!devices[i].isFrontFacing) {
                backCam = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
            }
        }

        if (backCam == null) {
            Debug.Log("Unable to find back camera");
            return;
        }

        backCam.Play();

        display.material.mainTexture = backCam;
    }

    private void Update() {

    }
}
