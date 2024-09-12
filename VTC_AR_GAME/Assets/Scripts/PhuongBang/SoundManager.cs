using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip backgroundSound;

    public AudioSource audioSourceVFX;
    public AudioClip getPointVFX;

    private void Start()
    {
        audioSource.clip = backgroundSound;
        audioSource.Play();
    }

    public void PlayVFX()
    {
        audioSourceVFX.clip = getPointVFX;
        audioSourceVFX.Play();
    }
}
