using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> needs a bottom door
    // 2 --> needs a top door 
    // 3 --> needs a left door
    // 4 --> needs a right door

    private RoomTemplates templates;
    private int randomNumber;
    public bool spawned;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (!spawned)
        {
            if (openingDirection == 1)
            {
                // Needs to spawn a room with a (BOTTOM) door
                randomNumber = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[randomNumber], transform.position, templates.bottomRooms[randomNumber].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                // Needs to spawn a room with a (TOP) door
                randomNumber = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[randomNumber], transform.position, templates.topRooms[randomNumber].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                // Needs to spawn a room with a (LEFT) door
                randomNumber = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[randomNumber], transform.position, templates.leftRooms[randomNumber].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                // Needs to spawn a room with a (RIGHT) door
                randomNumber = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[randomNumber], transform.position, templates.rightRooms[randomNumber].transform.rotation);
            }
            spawned = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
