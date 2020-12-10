using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject ArrowPrefab;
    public GameObject TargetPrefab;
    public GameObject Timer;

    public int score = 0;

    public GameObject aboveHeadNamePanel;
    public Text aboveHeadNameText;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            score--;
        }
    }

    public void TurnOnWinPanel()
    {
        if (score <= -1)
        {
            aboveHeadNamePanel.SetActive(true);
        }
    }

    public void SnowStorm()
    {
        SceneManager.LoadScene("SnowStorm");
    }

    public void CornField()
    {
        SceneManager.LoadScene("CornField");
    }

    public void Desert()
    {
        SceneManager.LoadScene("Desert");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Winner()
    {
        SceneManager.LoadScene("Winner");
    }
}
