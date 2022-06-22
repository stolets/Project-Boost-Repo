using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 3.0f;
   

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("this thing is friendly");
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            default:
                StartCrashSequence();
                break;


        }
    }

    void StartCrashSequence()
    {
        // todo add sound upon crash
        // todo add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);
    }

    void StartSuccessSequence() 
    {
        // todo add sound upon success
        // todo add particle effect on crash
        GetComponent<Movement>().enabled = false;
        Invoke("NextLevel", delay);
    }

    void ReloadLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings) 
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }

}
