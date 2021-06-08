// writted by victor, used https://www.youtube.com/watch?v=ih8gyGeC7xs&t=320s as a source. 
using UnityEngine;
using System.Collections;

public class Footsteps : MonoBehaviour 
{
    CharacterController Player;
    private AudioSource Audio;
    private double TimeElapsed = 0f;
    [SerializeField] private double FootstepFrequency;

    void Start () 
    {
        Player = GetComponent<CharacterController>();
        Audio = GetComponent<AudioSource>();
    }
 

        void Update () 
        {   
            this.TimeElapsed += Time.deltaTime;
            // check if player is on ground and moving 
            if ((Player.isGrounded == true) && (Player.velocity.magnitude > 3f) && (Audio.isPlaying == false) && (TimeElapsed >= FootstepFrequency))
            {  
                Audio.volume = Random.Range(0.3f, 0.45f);
                Audio.pitch = Random.Range(0.8f, 1.1f);
                Audio.Play();
                this.TimeElapsed = 0f;
            }
        }
}