using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public GameObject EnemyShipsPrefab;

    public Terrain MyTerrain;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 100; i++) {
            float x = Random.Range(MyTerrain.transform.position.x, MyTerrain.transform.position.x + MyTerrain.terrainData.size.x);
            float z = Random.Range(MyTerrain.transform.position.z, MyTerrain.transform.position.z + MyTerrain.terrainData.size.z);
            Vector3 pos = new Vector3(x, 0, z);

            float y = MyTerrain.SampleHeight(pos);
            pos.y = y;

            GameObject EnemyShips = Instantiate(EnemyShipsPrefab, pos, Quaternion.identity);

            EnemyShips.transform.Rotate(0, Random.Range(0, 360), 0);
        }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
