using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [Header("Objects:")]
    public GameObject[] objects;
    public GameObject self;

    [Header("Settings:")]
    public int interval = 1;
    public float nextTime = 0;
    public int spawnLimit = 10;
    public int currentlySpawned = 0;

    [Header("Setup:")]
    public GameObject minBoundsObj;
    public GameObject maxBoundsObj;
    bool bColliding = false;
    Vector3 minBoundsVec;
    Vector3 maxBoundsVec;
    Vector3 spawnLocation = new Vector3();
    BoxCollider2D hitBox;

    private void Start()
    {
        //Setting the spawn boundaries
        minBoundsVec = minBoundsObj.transform.position;
        maxBoundsVec = maxBoundsObj.transform.position;
        hitBox = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Time.time >= nextTime)
        {
            PositionTest();

            nextTime += interval;
        }
    }

    public void PositionTest()
    {
        if(currentlySpawned <= spawnLimit)
        {
            spawnLocation = RandomPosition(minBoundsVec, maxBoundsVec);
            transform.position = spawnLocation;

            //while (hitBox.bounds.Contains(spawnLocation))
            //while (hitBox.IsTouchingLayers(0))
            while (bColliding)
            {
                bColliding = false;
                spawnLocation = RandomPosition(minBoundsVec, maxBoundsVec);
                transform.position = spawnLocation;
                
            }
            InstantiatingEnemy();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //bColliding = true;
        Debug.Log("Collided!");

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        bColliding = true;
        Debug.Log("In excrutiating pain");
    }

    void OnCollisionExit2D(Collision2D other)
    {
        bColliding = false;
        Debug.Log("No longer in pain.");
    }

    public void InstantiatingEnemy()
    {
        int rand = Random.Range(0, objects.Length);
        Instantiate(objects[rand], spawnLocation, Quaternion.identity);
        currentlySpawned++;
    }

    public Vector3 RandomPosition(Vector3 minBounds, Vector3 maxBounds)
    {
        Vector3 newPos = new Vector3();
        newPos.x = Random.Range(minBounds.x, maxBounds.x);
        newPos.y = Random.Range(minBounds.y, maxBounds.y);

        return newPos;
    }
}