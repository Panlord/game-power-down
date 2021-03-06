using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject player;
    private float counter = 0f;
    private float time = 4f;
    private float range = 10f;

    public Transform target;
    public NavMeshAgent enemy;

    private bool Omniscient = false;

    // audio related
    private AudioSource Audio;
    public AudioClip scream;
    public AudioClip growl;
    private float Timer;
    private float TimeBetweenAudio = 10.0f;
    private bool HasScreamed = false;

    private string[] rooms = {"Conference Room A", "Conference Room A (1)", "Conference Room A (2)", "Conference Room A (3)",
                                "Conference Room A (4)", "Conference Room A (5)", "Conference Room B", "Conference Room B (1)", 
                                "Conference Room B (2)", "Small Office Room A", "Small Office Room A (1)", "Small Office Room A (2)",
                                "Small Office Room A (3)", "Small Office Room A (4)", "Small Office Room A (5)", "Small Office Room A (6)",
                                "Small Office Room A (7)", "Small Office Room B", "Small Office Room B (1)", "Small Office Room B (2)", 
                                "Small Office Room B (3)", "Small Office Room B (4)", "Small Office Room B (5)", "Small Office Room B (6)",
                                "Small Office Room B (7)", "Small Office Room C", "Small Office Room C (1)", "Small Office Room C (2)","Small Office Room C (3)",
                                "Small Office Room C (4)", "Small Office Room C (5)", "Small Office Room C (6)", "Small Office Room D (1)", "Small Office Room D (2)",
                                "Small Office Room D (3)", "Boys Restroom", "Boys Restroom (1)", "Girls Restroom", "Girls Restroom (1)", "Small Office Room D",
                                "Computer Room", "Computer Room (1)", "Computer Room (2)", "Computer Room (3)", "Computer Room (4)"};
    
    void Start()
    {
        Audio = GetComponent<AudioSource>();
    }
    // Warps the monster to a random position.
    public void WarpRandom()
    {
        int roomOrFloor = Random.Range(1,3); 
        if(roomOrFloor == 1)
        {
            int numOfFloor = Random.Range(7,128);
            string floor = "Floor_01_Snaps014 ("+numOfFloor.ToString()+")";
            this.monster.transform.position = new Vector3(GameObject.Find(floor).transform.position.x, this.monster.transform.position.y, GameObject.Find(floor).transform.position.z);
        }
        else
        {
            int numOfRoom = Random.Range(0, rooms.Length);
            this.monster.transform.position = new Vector3(GameObject.Find(rooms[numOfRoom]).transform.position.x, this.monster.transform.position.y, GameObject.Find(rooms[numOfRoom]).transform.position.z);
        }
    }

    public void GainKnowledge()
    {
        this.Omniscient = true;
    }

    public void Dumbdown()
    {
        this.Omniscient = false;
    }

    public void Halt()
    {
        this.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
    }

    public void Continue()
    {
        this.gameObject.GetComponent<NavMeshAgent>().isStopped = false;
    }
    void Update()
    {
        this.Timer += Time.deltaTime;
        // If the monster is near the player or the monster knows the player, chase the player.
        if(Vector3.Distance(player.transform.position, monster.transform.position)<=range || this.Omniscient)
        {
            //Debug.Log("monster nearby");
            enemy.SetDestination(player.transform.position);
            this.gameObject.GetComponent<NavMeshAgent>().speed = 10f;
            Audio.clip = growl;
            Audio.pitch = Random.Range(0.9f, 1.0f);
            Audio.PlayOneShot(growl, 0.3f);
            
        }
        // If enough time has passed and the monster doesn't see the player, warp.
        else if (counter >= time)
        {
            this.WarpRandom();
            this.gameObject.GetComponent<NavMeshAgent>().speed = 5f;
            counter = 0;

            if (HasScreamed == false)
            {
                Audio.clip = scream;
                Audio.pitch = Random.Range(0.8f, 1.0f);
                Audio.PlayOneShot(scream, 0.4f);
                HasScreamed = true;
            }
            
            if (Timer > TimeBetweenAudio)
            {
                Audio.clip = scream;
                Audio.pitch = Random.Range(0.8f, 1.0f);
                Audio.PlayOneShot(scream, 0.4f);
                this.Timer = 0.0f;
            }
        }
        // Otherwise pass the time.
        else
        {
            counter+=Time.deltaTime;
        }

    }
}
