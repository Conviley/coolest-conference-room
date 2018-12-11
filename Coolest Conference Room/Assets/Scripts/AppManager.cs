using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class AppManager : MonoBehaviour {

    public GameObject initialUi;

    private GameObject imageTarget;
    private AudioSource audioSource;
    public List<AudioClip> audioClips;
    public List<Sprite> phoneIcons;
    public Button phoneButton;
    public GameObject callShiaText;

    private bool instantiateShia = false;
    private bool calling = false;
    private GameObject videoPlane;
    private VideoPlayer video;

    private void Start() {
        imageTarget = GameObject.Find("ImageTarget");
        audioSource = GetComponent<AudioSource>();
        videoPlane = GameObject.Find("VideoPlane");
        video = videoPlane.GetComponent<VideoPlayer>();
        videoPlane.SetActive(false);
    }

    private void Update() {
        if (instantiateShia && !audioSource.isPlaying) {
            videoPlane.SetActive(true);
            video.Play();
            instantiateShia = false;
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
        videoPlane.SetActive(false);
        video.Stop();
    }

    public void InstantiateObject() {
        Instantiate(Resources.Load("Car"), imageTarget.transform);
    }

    private void CallShia() {
        audioSource.PlayOneShot(audioClips[0]);
        instantiateShia = true;
        callShiaText.SetActive(true);
        phoneButton.GetComponent<Image>().sprite = phoneIcons[0];
    }
}
