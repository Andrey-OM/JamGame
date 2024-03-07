using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class Trees : MonoBehaviour
{
    public GameObject fallingItem;
    public int count;
    public LayerMask ws;
    void Start()
    {
        var hit = Physics2D.Raycast(transform.position, transform.right, 0, ws).collider;
        System.Random rand = new Random();
        while (hit?.tag == "Build")
        {
            int x = rand.Next(-40, 50);
            int y = rand.Next(-30, 40);
            transform.position = new Vector2(x, y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
