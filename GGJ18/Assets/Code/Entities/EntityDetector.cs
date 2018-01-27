using System.Collections.Generic;
using UnityEngine;

public class EntityDetector : MonoBehaviour
{
    public List<GameObject> NpcsInsideTrigger;


    private void Start()
    {
        NpcsInsideTrigger = new List<GameObject>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.tagNpcs))
        {
            NpcsInsideTrigger.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Constants.tagNpcs))
        {
            NpcsInsideTrigger.Remove(other.gameObject);
        }
    }
}