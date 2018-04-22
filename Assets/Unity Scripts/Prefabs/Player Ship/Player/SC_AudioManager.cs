using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SC_AudioManager : MonoBehaviour {

	public AudioMixerGroup AudioMixer;
	public AudioClip[] AudioClip;

    public void PlayAudio(int idAudio)
    {
        AudioSource AudioSource = this.gameObject.AddComponent<AudioSource>();
        AudioSource.outputAudioMixerGroup = AudioMixer;
        AudioSource.clip = AudioClip[idAudio];
        AudioSource.Play();
        Destroy(AudioSource, 2);
    }

    public void PlayAudio(int idAudio, float volume)
	{
		AudioSource AudioSource = this.gameObject.AddComponent<AudioSource>();
        AudioSource.outputAudioMixerGroup = AudioMixer;
		AudioSource.clip = AudioClip[idAudio];
        AudioSource.volume = volume;
		AudioSource.Play();
		Destroy(AudioSource, 2);
	}

    public void PlayAudio(int idAudio, float volume, GameObject camera)
    {
        AudioSource AudioSource = camera.AddComponent<AudioSource>();
        AudioSource.outputAudioMixerGroup = AudioMixer;
        AudioSource.clip = AudioClip[idAudio];
        AudioSource.volume = volume;
        AudioSource.Play();
        Destroy(AudioSource, 2);
    }

}
