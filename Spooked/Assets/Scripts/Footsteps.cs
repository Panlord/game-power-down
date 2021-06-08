// writted by victor, used https://www.youtube.com/watch?v=ih8gyGeC7xs&t=320s as a source. 
using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour 
{

    // Use this for initialization
    CharacterController Player;
    private AudioSource Audio;
    void Start () 
    {
            Player = GetComponent<CharacterController>();
            Audio = GetComponent<AudioSource>();
    }
 
 // Update is called once per frame
        void Update () {
        if (Player.isGrounded == true && (Player.velocity.magnitude > 3f) && Audio.isPlaying == false)
        {  
            Audio.volume = Random.Range(0.3f, 0.45f);
            Audio.pitch = Random.Range(0.8f, 1.1f);
            Audio.Play();
        }
 }
}