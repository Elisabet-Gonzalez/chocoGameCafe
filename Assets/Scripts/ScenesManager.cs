using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public Animator trans;
    [SerializeField] private float time = 0.5f;
    

    public void NextScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex +1));

    }

    public void BeforeScene()
    {
        StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex - 1));
    }

    IEnumerator LoadScene(int index)
    {
        trans.SetTrigger("Start");

        yield return new WaitForSeconds(time);

        SceneManager.LoadScene(index);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Bye Bye");
    }
    
   
}
