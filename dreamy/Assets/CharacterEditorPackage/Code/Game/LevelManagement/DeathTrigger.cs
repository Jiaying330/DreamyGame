using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
//--------------------------------------------------------------------
//When the player enters, respawn them
//--------------------------------------------------------------------
public class DeathTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider a_Collider)
    {
        if (a_Collider.tag == "Death") {
            Debug.Log("Death triggered by: " + transform.name);
                // if (InSceneLevelSwitcher.Get())
                // {
                //     InSceneLevelSwitcher.Get().Respawn();
                // }
                // StartCoroutine(waitForSound("Death"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        ControlledCapsuleCollider controlledCapsuleCollider = a_Collider.GetComponent<ControlledCapsuleCollider>();
        if (controlledCapsuleCollider != null)
        {
            // Debug.Log("a_Collider = " + a_Collider);
            //Prevent death state to be used if the collider is no-clipping
            if (controlledCapsuleCollider.AreCollisionsActive())
            { 
                Debug.Log("Death triggered by: " + transform.name);
                // if (InSceneLevelSwitcher.Get())
                // {
                //     InSceneLevelSwitcher.Get().Respawn();
                // }
                // StartCoroutine(waitForSound("Death"));
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // IEnumerator waitForSound(string sound)
    // {
    //     FindObjectOfType<AudioManager>().Play(sound);
    //     Debug.Log(FindObjectOfType<AudioManager>().isPlaying(sound));

    //     while(FindObjectOfType<AudioManager>().isPlaying(sound))
    //     {
    //         Debug.Log("in while loop : " + FindObjectOfType<AudioManager>().isPlaying(sound));
    //         yield return null;
    //     }
        
    //     // yield return new WaitWhile(() => FindObjectOfType<AudioManager>().isPlaying(sound));
    //     Debug.Log("third " + FindObjectOfType<AudioManager>().isPlaying(sound));
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
