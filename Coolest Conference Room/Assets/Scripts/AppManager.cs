using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {

    public GameObject initialUi;
    public GameObject translationUi;
    public GameObject videoPlane;

    private float previousSliderValue;

    private bool inTranslationMode = false;

    private Camera cam;

    private void Start () {
        cam = Camera.main;
        translationUi.SetActive(false);
	}

    private void Update() {
        if (!inTranslationMode && Input.GetMouseButton(0)) {
            Vector3 mouseposition = Input.mousePosition;
            mouseposition.z = videoPlane.transform.position.z;
            mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

            videoPlane.transform.position = mouseposition;
        }
    }

    public void ShowTranslationUI() {
        if (translationUi.activeSelf == true) {
            translationUi.SetActive(false);
            inTranslationMode = false;
        } else {
            translationUi.SetActive(true);
            inTranslationMode = true;
        }
    }

    public void MovePlaneInZ(float sliderValue) {
        float moveAmount = previousSliderValue - sliderValue;

        videoPlane.transform.Translate(Vector3.up * moveAmount);

        previousSliderValue = sliderValue;
    }
}
