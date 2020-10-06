using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightSpriteMenuMaskBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int dayOrNight = Random.Range(0, 2);
        Debug.Log(dayOrNight);
        if (dayOrNight == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
