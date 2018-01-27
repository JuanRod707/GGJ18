using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour {

    public WarpScript WrpDestination;
    public Transform RecieverPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerWarp>().Warp(WrpDestination.RecieverPoint.position);
        }
    }
}
