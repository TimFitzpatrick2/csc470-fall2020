using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManger : MonoBehaviour
{
    public GameObject WorldPrefab;
    public GameObject DogBone;
    GameObject ground;

    float makeboneTime = .06f;
    float makeboneRate = .06f;

    int numWorldz = 0;
    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        makeboneTime -= Time.deltaTime;
        if (makeboneTime < 0){
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-200, 200)
                                , ground.transform.position.y + 100,
                                ground.transform.position.z + Random.Range(-200, 200));
            GameObject drop = Instantiate(DogBone, pos, Quaternion.identity);
            Renderer rend = drop.GetComponent<Renderer>();
            rend.material.color = new Color(Random.value, Random.value, Random.value);
            Destroy(drop, 1f);

            makeboneTime = makeboneRate;
        }
    }

    public void MakeMoreWorldz()
    {
        numWorldz++;

        if (numWorldz < 10)
        {



            Debug.Log("Make Worldz");
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(-20, 20)
                                    , ground.transform.position.y + 50,
                                    ground.transform.position.z + Random.Range(-20, 20));
            Instantiate(WorldPrefab, pos, Quaternion.identity);
        } else {
            SceneManager.LoadScene("New World");
        }
    }
}
