using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {

    public GameObject initialUi;
    public GameObject translationUi;
    private GameObject imageTarget;

    private void Start () {
        translationUi.SetActive(false);
        imageTarget = GameObject.Find("ImageTarget");
	}

    private void Update() {

    }

    public void ShowTranslationUI() {

    }

    public void instantiateObject() {
        Instantiate(Resources.Load("Engine"), imageTarget.transform);
    }
}
