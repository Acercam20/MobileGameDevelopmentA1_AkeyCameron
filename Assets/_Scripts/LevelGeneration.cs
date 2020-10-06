using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{

    public Transform[] startingPositions;
    public GameObject[] rooms;

    //private int direction;

    private void Start()
    {
        int StartingPos = 0;
        transform.position = startingPositions[StartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);
        for (int i = 0; i < startingPositions.Length; i++)
        {
            transform.position = startingPositions[i].position;
            Instantiate(rooms[Random.Range(0, rooms.Length)], transform.position, Quaternion.identity);
        }
        //direction = Random.Range(1, 6); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
