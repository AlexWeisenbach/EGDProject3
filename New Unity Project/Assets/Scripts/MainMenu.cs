using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("TransitionScene", LoadSceneMode.Single);
    }

    public void StartLooking()
    {
        SceneManager.LoadScene("CrimeScene");
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
