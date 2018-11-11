using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlaySoundController : MonoBehaviour
{
    public GameObject Speaker;
    public AudioClip OneShotSoundClip;
    public float SpeakerVolume;
    AudioSource SpeakerSource;

	// Use this for initialization
	void Start ()
    {
        SpeakerSource = Speaker.GetComponent<AudioSource>();
	}

    public void PlaySoundOneShot()
    {
        SpeakerSource.PlayOneShot(OneShotSoundClip, SpeakerVolume);
    }
	

}
