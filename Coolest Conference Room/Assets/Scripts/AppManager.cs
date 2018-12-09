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
    public GameObject callShieText;

    private bool instantiateShia = false;
    private bool calling = false;

    private void Start () {
        imageTarget = GameObject.Find("ImageTarget");
        audioSource = GetComponent<AudioSource>();
	}

    private void Update() {
        if (instantiateShia && !audioSource.isPlaying) {
            Instantiate(Resources.Load("VideoPlane"), imageTarget.transform);
            instantiateShia = false;
            callShieText.active = false;    
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
        Destroy(GameObject.Find("VideoPlane"));
        phoneButton.GetComponent<Image>().sprite = phoneIcons[1];
        callShieText.active = false;
        instantiateShia = false;
    }

    public void instantiateObject() {
        Instantiate(Resources.Load("Cube"), imageTarget.transform);
    }

    private void CallShia() {
        audioSource.PlayOneShot(audioClips[0]);
        instantiateShia = true;
        callShieText.active = true;
        phoneButton.GetComponent<Image>().sprite = phoneIcons[0];
    }
}
