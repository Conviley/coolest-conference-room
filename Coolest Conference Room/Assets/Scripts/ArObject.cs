using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ArObject : MonoBehaviour {

    public float movementSpeed = .05f;
    public float depthSpeed = .1f;
    public float xThresh = 10f;
    public float yThresh = 10f;
    public float zThresh = 15f;
    public float fadeSpeed = 400;

    private float prevTouchX = 0;
    private float prevTouchY = 0;

    private bool selected = false;
    private GameObject imageTarget;
   
    void Start () {
        imageTarget = GameObject.Find("ImageTarget");
        Vector3 imageTargetPosition = imageTarget.transform.position;
        Vector3 spawnPositon = new Vector3(imageTargetPosition.x, transform.position.y, imageTargetPosition.z);
        transform.position = spawnPositon;
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
                        transform.Translate(Vector3.right * movementSpeed, Space.World);
                    } else {
                        transform.Translate(Vector3.left * movementSpeed, Space.World);
                    }
                }

                if (yDistance > yThresh) {
                    if (touchY > prevTouchY) {
                        transform.Translate(Vector3.up * movementSpeed, Space.World);
                    } else {
                        transform.Translate(Vector3.down * movementSpeed, Space.World);
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
                    transform.Translate(Vector3.forward * depthSpeed, Space.World);
                } else {
                    transform.Translate(Vector3.back * depthSpeed, Space.World);
                }
            }

            prevTouchY = touchPosition.y;
        }
    }

    private void OnMouseDown() {
        Debug.Log("CLICKED");
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
