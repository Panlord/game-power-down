// from unity audioclip docs 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusic : MonoBehaviour
{

    public AudioClip otherClip;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        // play new audio clip when previous one ends
        audio.clip = otherClip;
        audio.Play();

    }

    
}
