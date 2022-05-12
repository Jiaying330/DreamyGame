using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject completeLevelUI;
    public Button PlayAgain;

    void Start() 
    {
        PlayAgain.onClick.AddListener(PlayAgainOnClick);
    }

    void OnTriggerEnter (Collider collider)
    {
        if (collider.tag == "Player") 
            completeLevelUI.SetActive(true);
    }

    void PlayAgainOnClick()
    {
        completeLevelUI.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
