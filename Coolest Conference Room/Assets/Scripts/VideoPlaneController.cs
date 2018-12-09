using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlaneController : MonoBehaviour {

    public float movementSpeed = .05f;
    public float depthSpeed = .1f;
    public float xThresh = 10f;
    public float yThresh = 10f;
    public float zThresh = 15f;
    public float fadeSpeed = 400;

    private float prevTouchX = 0;
    private float prevTouchY = 0;

    private bool selected = false;

    void Start () {
        VideoPlayer videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.aspectRatio = VideoAspectRatio.FitOutside;
    }

    void Update() {
        if (selected) { 
            GetComponent<Renderer>().material.color = new Color32(0, (byte)Mathf.PingPong(Time.time * fadeSpeed, 255), 0, 255);
            TranslateAndScale();
        }
    }

    private void TranslateAndScale() {
        if (Input.touchCount == 1) {
            Touch touchZero = Input.GetTouch(0);

            if (touchZero.phase == TouchPhase.Moved) {
                float touchX = touchZero.position.x;
                float touchY = touchZero.position.y;

                float xDistance = Mathf.Abs(touchX - prevTouchX);
                float yDistance = Mathf.Abs(touchY - prevTouchY);

                if (xDistance > xThresh) {
                    if (touchX > prevTouchX) {
                        transform.Translate(Vector3.left * movementSpeed);
                    } else {
                        transform.Translate(Vector3.right * movementSpeed);
                    }
                }

                if (yDistance > yThresh) {
                    if (touchY > prevTouchY) {
                        transform.Translate(Vector3.back * movementSpeed);
                    } else {
                        transform.Translate(Vector3.forward * movementSpeed);
                    }
                }

                prevTouchX = touchX;
                prevTouchY = touchY;
            }
        } else if (Input.touchCount == 2) {
            // Flytta i Z-led
            Vector3 touchPosition = Input.GetTouch(0).position;
            float yDistance = Mathf.Abs(touchPosition.y - prevTouchY);
            if (yDistance > zThresh) {
                if (touchPosition.y > prevTouchY) {
                    transform.Translate(Vector3.down * depthSpeed);
                } else {
                    transform.Translate(Vector3.up * depthSpeed);
                }
            }

            prevTouchY = touchPosition.y;
        }
    }

    private void OnMouseDown() {
        if (!selected) {
            selected = true;
        } else {
            selected = false;
            GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
        }
    }

    public bool isSelected() {
        return selected;
    }
}
