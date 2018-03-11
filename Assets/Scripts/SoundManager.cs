using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioSource bgSource;
    public AudioSource efSource;
    public static SoundManager instance = null;
    public float lowPitchRange = .95f;
    public float highPitchRange = 1.05f;

    void Awake()
    {
        if (instance == null) {
            instance = this;
        } else if (instance!=this) {
            Destroy(gameObject);
        }
    }

    public void PlaySingle(AudioClip clip) {
        efSource.clip = clip;
        efSource.Play();
    }

    public void RandomizeSfx(params AudioClip[] clips) {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efSource.pitch = randomPitch;
        efSource.clip = clips[randomIndex];
        efSource.Play();
    }

    public void ChangeBgAudio(AudioClip clip) {
        bgSource.clip = clip;
        bgSource.Play();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
