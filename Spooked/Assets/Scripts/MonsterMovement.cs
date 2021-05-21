using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private GameObject player;
    private float LerpDuration = 0.01f;

    private Vector3 MovementDirection;
    private float counter = 0f;

    void Update()
    {
        this.MovementDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);
        var playerPosition = this.player.transform.position;
        var monsterPosition = this.monster.transform.position;

        // if the player stops moving, monster lerps to its direction
        if(this.MovementDirection.Equals(Vector3.zero))
        {
            monsterPosition = Vector3.Lerp(monsterPosition, new Vector3(playerPosition.x, playerPosition.y, playerPosition.z), LerpDuration);
            this.monster.transform.position = monsterPosition;
            this.counter=0;
        }

        // if the player is currently moving, start lerping after some time (0.3 seconds)
        else
        {
            this.counter+=Time.deltaTime;
            if(this.counter>=0.3f)
            {
                monsterPosition = Vector3.Lerp(monsterPosition, new Vector3(playerPosition.x, playerPosition.y, playerPosition.z), LerpDuration);
                this.monster.transform.position = monsterPosition;
            } 
        }
    }
}