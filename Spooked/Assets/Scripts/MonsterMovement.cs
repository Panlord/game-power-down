using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject player;
    private float counter = 0f;
    private float time = 5f;
    private float range = 20f;

    public Transform target;
    public NavMeshAgent enemy;

    private bool Omniscient = false;

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
        this.gameObject.GetComponent<NavMeshAgent>().speed = 6f;
    }

    public void Dumbdown()
    {
        this.Omniscient = false;
        this.gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;
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
        
        enemy.SetDestination(target.position);

        if(counter>=time)
        {

            if(Vector3.Distance(player.transform.position, monster.transform.position)<=range || this.Omniscient)
            {
                //Debug.Log("monster nearby");
                enemy.SetDestination(target.position);
            }
            else
            {
                this.WarpRandom();
                counter = 0;
            }
        }

        else
        {
            counter+=Time.deltaTime;
        }

    }
}
