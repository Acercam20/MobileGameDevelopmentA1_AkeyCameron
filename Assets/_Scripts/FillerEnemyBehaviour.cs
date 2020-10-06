using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillerEnemyBehaviour : MonoBehaviour
{
    public int Health = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Health--;
            if (Health == 3)
            {
                Debug.Log("I'm still alive, only I'm very badly burnt");
            }
            if (Health == 2)
            {
                Debug.Log("You shot me!");
            }
            if (Health == 1)
            {
                Debug.Log("You shot me right in the arm! Why did you-");
            }
            if (Health == 0)
            {
                Debug.Log("Rest in piece, Mufasa.");
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }
}
