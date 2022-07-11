using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{

    [SerializeField] float delay = 3.0f;
    [SerializeField] AudioClip Success;
    [SerializeField] AudioClip Death;

    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;
    

    AudioSource audioSource;
    

    bool isTransitioning = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (isTransitioning){return;}

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
        deathParticles.Play();
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(Death);
        }
        Invoke("ReloadLevel", delay);
    }

    void StartSuccessSequence() 
    {

        successParticles.Play();
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        if (!audioSource.isPlaying)
        {
        audioSource.PlayOneShot(Success);
        }
        
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
