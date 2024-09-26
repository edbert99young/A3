using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    public AudioClip IntroBackground;
    public AudioClip NormalState;

    void Start()
    {
        StartCoroutine(playSound());
    }

    IEnumerator playSound()
    {
        GetComponent<AudioSource>().clip = IntroBackground;
        yield return new WaitForSeconds(IntroBackground.length);
        GetComponent<AudioSource>().clip = NormalState;
        GetComponent<AudioSource>().Play();
    }
}
