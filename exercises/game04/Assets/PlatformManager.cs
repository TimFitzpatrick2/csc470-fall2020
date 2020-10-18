using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject CubePrefab;

    
    GameObject ground;

    float makePlatformTimer = 0.0f;
    float makePlatformRate = 0.0f;

    int numPlatform = 100;

    // Start is called before the first frame update
    void Start()
    {
        ground = GameObject.Find("Ground");

    }

    // Update is called once per frame
    void Update()
    {
        makePlatformTimer -= Time.deltaTime;
        if (makePlatformTimer < 0) {

            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(0, 300), ground.transform.position.y + 0, ground.transform.position.z + Random.Range(0, 500));

            GameObject spond = Instantiate(CubePrefab, pos, Quaternion.identity);


            makePlatformTimer = makePlatformRate;

            Destroy(spond, 10f);

            Renderer rend = spond.GetComponent<Renderer>();
            rend.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }

    public void MakeMorePlatforms()
    {
        if (numPlatform < 50)
        {
            Vector3 pos = new Vector3(ground.transform.position.x + Random.Range(0, 10), ground.transform.position.y + 10, ground.transform.position.z + Random.Range(0, 10));

            Instantiate(CubePrefab, pos, Quaternion.identity);
        
        }
    }
}
