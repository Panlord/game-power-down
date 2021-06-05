using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Monster" && collision.gameObject.activeSelf)
        {
            this.GameOver = true;
        }
    }
}
