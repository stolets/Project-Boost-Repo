using UnityEngine;

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
                Debug.Log("Finish point reached");
                break;
            case "Fuel":
                Debug.Log("Re-fueled");
                break;
            default:
                Debug.Log("Sorry, you blew up");
                break;


        }
    }

}
