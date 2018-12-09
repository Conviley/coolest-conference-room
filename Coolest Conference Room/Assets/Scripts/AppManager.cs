using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour {

    public GameObject initialUi;
    public GameObject translationUi;

    private void Start () {
        translationUi.SetActive(false);
	}

    private void Update() {

    }

    public void ShowTranslationUI() {

    }
}
