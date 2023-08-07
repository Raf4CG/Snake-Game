using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    //Limits for foods
    public Transform BorderTOP;
    public Transform BorderBOTTOM;
    public Transform BorderLEFT;
    public Transform BorderRIGHT;
    
    //Prefab: Food
    public GameObject foodPrefab;

    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);
            }

    void Spawn()
    {
        //Location for foods
        int x=(int) Random.Range(BorderLEFT.position.x, BorderRIGHT.position.x);
        int y=(int) Random.Range(BorderTOP.position.y, BorderBOTTOM.position.y);
        
        //Creat food
        Instantiate(foodPrefab, new Vector2(x,y), Quaternion.identity);

    }
}
