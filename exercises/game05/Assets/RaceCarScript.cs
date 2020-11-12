using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceCarScript : MonoBehaviour
{
    GameManager gm;

    public bool selected = false;
    public bool hover = false;

    public Color defaultColor;
    public Color hoverColor;
    public Color selectedColor;
    public string unitName;
    public GameObject Unit;

    public Renderer rend;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManagerObject").GetComponent<GameManager>();
        UpdateVisuals();
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    targetPosition = hit.point;
                }
            }
        }
    }

    public void UpdateVisuals()
    {
        if (selected)
        {
            rend.material.color = selectedColor;
        }
        else
        {
            if (hover)
            {
                rend.material.color = hoverColor;
            }
            else
            {
                rend.material.color = defaultColor;
            }
        }
    }

    private void OnMouseEnter()
    {
        gm.PositionRaceCarPanel(this);
        hover = true;
        UpdateVisuals();
    }

    private void OnMouseExit()
    {
        gm.TurnOffRaceCarPanel();
        hover = false;
        UpdateVisuals();
    }

    private void OnMouseDown()
    {
        selected = !selected;
        if (selected)
        {
            gm.SelectNewUnit = this;
        }

        UpdateVisuals();

    }
}
