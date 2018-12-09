using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppManager : MonoBehaviour {

    public GameObject initialUi;

    private GameObject imageTarget;
    private AudioSource audioSource;
    public List<AudioClip> audioClips;
    public List<Sprite> phoneIcons;
    public Button phoneButton;
    public GameObject callShiaText;

    private bool instantiateShia = false;
    private bool shiaOut = false;
    private bool calling = false;
    private GameObject shia;

    private void Start() {
        imageTarget = GameObject.Find("ImageTarget");
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (instantiateShia && !audioSource.isPlaying) {
            shia = (GameObject)Instantiate(Resources.Load("VideoPlane"), imageTarget.transform);
            instantiateShia = false;
            shiaOut = true;
            callShiaText.SetActive(false);
        }
    }

    public void HandlePhoneButtonClick() {
        if (!calling) {
            CallShia();
            calling = true;
        } else {
            HangUp();
            calling = false;
        }
    }

    private void HangUp() {
        audioSource.Stop();
        audioSource.PlayOneShot(audioSource.clip);
        phoneButton.GetComponent<Image>().sprite = phoneIcons[1];
        callShiaText.SetActive(false);
        instantiateShia = false;
        Destroy(shia);
        shiaOut = false;
    }

    public void instantiateObject() {
        Instantiate(Resources.Load("Cube"), imageTarget.transform);
    }

    private void CallShia() {
        audioSource.PlayOneShot(audioClips[0]);
        instantiateShia = true;
        callShiaText.SetActive(true);
        phoneButton.GetComponent<Image>().sprite = phoneIcons[0];
    }

    public GameObject GetVideoPlane() {
        return shia;
    }

    public bool isShiaOut() {
        return shiaOut;
    }

}
