using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInstructionsButtonPressed()
    {
        Debug.Log("InstructionsButton Pressed");
        SceneManager.LoadScene("Instructions");
    }
}
