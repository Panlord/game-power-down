using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    private bool Showing;
    private Vector3 PlayerLocation;

    public MapController()
    {
        this.Showing = false;
    }

    private void Show()
    {
        this.Showing = true;
        Debug.Log("Map Showing");
        // Display the map here.
    }

    public void Hide()
    {
        this.Showing = false;
        Debug.Log("Map Hidden");
        // Put away the map here.
    }

    private void UpdateMap()
    {
        // Update the map's appearance using the player's location and the surrounding area.
    }

    // Let the GameController if it is allowed to notify the monster with the player's position.
    public bool CanSignalMonster()
    {
        return this.Showing;
    }

    void Update()
    {
        // Show or hide the map.
        if (Input.GetButtonDown("Fire2"))
        {
            if (this.Showing)
            {
                this.Hide();
            }
            else
            {
                this.Show();
            }
        }

        if (this.Showing)
        {
            this.UpdateMap();
        }
    }
}