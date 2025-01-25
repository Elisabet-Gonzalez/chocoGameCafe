using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    } 
    
    public void QuitGame()
    {
        Debug.Log("Bye Bye");
        Application.Quit();
    }
   
   
}
