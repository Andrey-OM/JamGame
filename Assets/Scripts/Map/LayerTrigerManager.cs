using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class LayerTrigerManager : MonoBehaviour
{
    public string layer;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(layer);
        other.gameObject.layer = LayerMask.NameToLayer(layer);
        other.gameObject.GetComponent<SpriteRenderer>().sortingLayerName = layer;
        SpriteRenderer[] srs = other.gameObject.GetComponentsInChildren<SpriteRenderer>();
        Debug.Log("пока");
        foreach (SpriteRenderer sr in srs)
        {
            sr.sortingLayerName = layer;
        }
    }
}
