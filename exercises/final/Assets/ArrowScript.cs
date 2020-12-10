using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowScript : MonoBehaviour
{
    GameManager gm;

    public int score = 5;

    public AudioClip[] clips;
    public AudioSource audioSource;
    int audioIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.Find("GameManagerObj").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(other.gameObject);
            //audioSource.clip = clips[audioIndex % clips.Length];
            //audioIndex++;
            //audioSource.Play();

            score--;

        }
    }
}
