using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
	public static AudioManager Instance;
	public AudioSource GameSFX;
	public AudioSource GameMusic;

	private void Awake()
	{
		if (Instance == null) { Instance = this; }
		else { Destroy(gameObject); }
	}

	public void PlayGameSFX(AudioClip clip) 
	{
		GameSFX.PlayOneShot(clip);
	}

	public void PlayGameMusic() 
	{
		GameMusic.Play();
	}

	public void StopGameMusic() 
	{
		GameMusic.Stop();
	}
}
