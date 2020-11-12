using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    GameManager gm;

    public bool selected = false;
    public bool hover = false;

    public Color defaultColor;
    public Color hoverColor;
    public Color selectedColor;
    public string unitName;
    public GameObject Unit;
    public GameObject crosshairs;
    public GameObject Arrow;
    public GameObject ArrowPrefab;

    public float ArrowSpeed = 1500.0f;

    private Vector3 target;
    public Renderer rend;

    Rigidbody rb;

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
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshairs.transform.position = new Vector3(target.x, target.y, target.z);

        

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(ArrowSpeed);
            GameObject Arrow = Instantiate(ArrowPrefab, transform.position + transform.forward * 10, transform.rotation);
            Rigidbody ArrowRB = Arrow.GetComponent<Rigidbody>();
            ArrowRB.AddForce(transform.forward * ArrowSpeed);
            Destroy(Arrow, 5);
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
        gm.PositionTargetPanel(this);
        hover = true;
        UpdateVisuals();
    }

    private void OnMouseExit()
    {
        gm.TurnOffTargetPanel();
        hover = false;
        UpdateVisuals();
    }

    private void OnMouseDown()
    {
        selected = !selected;
        if (selected)
        {
            gm.SelectTarget = this;
        }

        UpdateVisuals();

    }
}

     
