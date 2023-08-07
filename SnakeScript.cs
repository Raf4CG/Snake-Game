using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeScript : MonoBehaviour
{
    //Snake direction
    Vector2 dir = Vector2.right;
    //If the snake eat the food
    bool ate = false;
    //Tail prefab
    public GameObject tailPrefab;
    //Tail
    List<Transform> tail = new List<Transform>();


    void Start()
    {
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        //Controls
        if (Input.GetKey(KeyCode.RightArrow))
        dir = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow))
        dir = -Vector2.right;
        else if (Input.GetKey(KeyCode.UpArrow))
        dir = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow))
        dir = -Vector2.up;
    
    }

    void Move()
    {
        //save coord
        Vector2 v = transform.position;
        //Head moviment
        transform.Translate(dir);
        //Tail moviment
        if (ate)
        {   
            //Create a tail
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);
            //Mark the element has the tail start
            tail.Insert(0, g.transform);
            //eat?
            ate = false;
        }
        else if(tail.Count>0)
        {
            //Change coord of element in to screen
            tail[tail.Count - 1].position = v;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll) 
    {
        //It's food?
        if (coll.name.StartsWith("Food"))
        {
            ate = true;   
            Destroy(coll.gameObject);    
        }
        else
        {
            //End game
            Debug.Log("Died!");
        }
    }
}

