using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public UnitScript SelectUnit;
    public RaceCarScript SelectNewUnit;
    public GameObject namePanel;
    public GameObject SurfPanel;
    public GameObject RaceCarPanel;
    public GameObject TargetPanel;
    public GameObject[] GameObjects;
    public GameObject CoinPrefab;
    public TargetScript SelectTarget;


    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PositionSurfPanel(UnitScript unit)
    {
        Vector3 pos = unit.gameObject.transform.position + Vector3.up * 2;
        SurfPanel.SetActive(true);
        SurfPanel.transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    public void TurnOffSurfPanel()
    {
        SurfPanel.SetActive(false);
    
    }

    public void SelectedUnit(UnitScript toSelect)
    {
        SelectUnit = toSelect;

        if (GameObjects == null)
            GameObject.FindGameObjectWithTag("Unit");
        for (int i = 0; i < GameObjects.Length; i++)
        {
            UnitScript unitScript = GameObjects[i].GetComponent<UnitScript>();
            unitScript.selected = false;
            unitScript.UpdateVisuals();
        }

        if (toSelect != null)
        {
            SelectUnit.selected = true;


            SelectUnit.UpdateVisuals();

        } else {

            SurfPanel.SetActive(false);

        }
    }

    public void PositionRaceCarPanel(RaceCarScript unit)
    {
        Vector3 pos = unit.gameObject.transform.position + Vector3.up * 2;
        RaceCarPanel.SetActive(true);
        RaceCarPanel.transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    public void TurnOffRaceCarPanel()
    {
        RaceCarPanel.SetActive(false);

    }

    public void NewSelectedUnit(RaceCarScript toSelect)
    {
        

        if (GameObjects == null)
            GameObject.FindGameObjectWithTag("RaceCar");
        for (int i = 0; i < GameObjects.Length; i++)
        {
            RaceCarScript racecarScript = GameObjects[i].GetComponent<RaceCarScript>();
            racecarScript.selected = false;
            racecarScript.UpdateVisuals();
        }

        if (toSelect != null)
        {
            SelectUnit.selected = true;


            SelectUnit.UpdateVisuals();

        }
        else
        {

            RaceCarPanel.SetActive(false);

        }
    }

    public void PositionTargetPanel(TargetScript unit)
    {
        Vector3 pos = unit.gameObject.transform.position + Vector3.up * 2;
        TargetPanel.SetActive(true);
        TargetPanel.transform.position = Camera.main.WorldToScreenPoint(pos);
    }

    public void TurnOffTargetPanel()
    {
        TargetPanel.SetActive(false);

    }

    public void TargetSelectedUnit(TargetScript toSelect)
    {


        if (GameObjects == null)
            GameObject.FindGameObjectWithTag("Andy");
        for (int i = 0; i < GameObjects.Length; i++)
        {
            TargetScript targetScript = GameObjects[i].GetComponent<TargetScript>();
            targetScript.selected = false;
            targetScript.UpdateVisuals();
        }

        if (toSelect != null)
        {
            SelectUnit.selected = true;


            SelectUnit.UpdateVisuals();

        }
        else
        {

            TargetPanel.SetActive(false);

        }
    }


    public void Shredding()
    {
        SceneManager.LoadScene("Shredding");
    }

    public void RaceTrack()
    {
        SceneManager.LoadScene("RaceTrack");
    }

    public void MainMap()
    {
        SceneManager.LoadScene("MainMap");
    }

    public void TargetPractice()
    {
        SceneManager.LoadScene("TargetPractice");
    }
    public void TitleScreen()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
