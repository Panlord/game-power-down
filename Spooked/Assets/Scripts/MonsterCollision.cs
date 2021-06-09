// Author: Erik.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls a collider for a sphere that represents the player.
public class MonsterCollision : MonoBehaviour
{
    private bool GameOver = false;

    public void Reset()
    {
        this.GameOver = false;
    }

    public bool Hit()
    {
        return this.GameOver;
    }

    // If the player hits the monster, notify GameController to execute Game Over sequence.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Monster" && collision.gameObject.activeSelf)
        {
            this.GameOver = true;
        }
    }
}
