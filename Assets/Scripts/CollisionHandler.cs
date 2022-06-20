using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag) 
        {
            case "Friendly":
                Debug.Log("this thing is friendly");
                break;

            case "Finish":
                NextLevel();
                Debug.Log("Finish point reached");
                break;

            case "Fuel":
                Debug.Log("Re-fueled");
                break;

            default:
                ReloadLevel();
                Debug.Log("Sorry, you blew up");
                break;


        }
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
