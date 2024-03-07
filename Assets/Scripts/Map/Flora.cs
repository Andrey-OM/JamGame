using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Linq;

public class Flora : MonoBehaviour
{
    public Tilemap tileMapLand;
    public static int countTrees = 20;
    public GameObject[] Trees;
    private void Start()
    {
        (Stack<GameObject> treesLine, int sum) = GenerateFloraScale(Trees, countTrees);
        System.Random rand = new System.Random();
        int x, y;
        for (int i = 0; i < sum; i++)
        {
            x = rand.Next(-40, 50);
            y = rand.Next(-30, 40);
            if (treesLine.Count != 0)
            {
                Instantiate(treesLine.Pop(), new Vector2(x, y), Quaternion.identity);
            }
        }
    }

    private (Stack<GameObject>, int) GenerateFloraScale(GameObject[] Trees, int countTrees)
    {

        Stack<GameObject> treesLine = new Stack<GameObject>();
        int sumOfObjects = 0;
        System.Random rand = new System.Random();
        float ie = rand.Next(0, Trees.Length);
        foreach (GameObject tree in Trees)
        {
            int count = tree.GetComponent<Trees>().count;
            for (int i = 0; i < count; i++)
            {
                sumOfObjects++;
                treesLine.Push(tree);
            }
        }
        Debug.Log($"{ treesLine.Count} { sumOfObjects}");
        return (treesLine, sumOfObjects);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            //Instantiate(fallingItem, transform.position, Quaternion.identity);
        }
    }
}
