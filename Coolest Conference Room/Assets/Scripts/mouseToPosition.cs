using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseToPosition : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 mouseposition = Input.mousePosition;
        mouseposition.z = Camera.main.nearClipPlane;
        mouseposition = Camera.main.ScreenToWorldPoint(mouseposition);

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(mouseposition);
        }

  
        

    }
}
