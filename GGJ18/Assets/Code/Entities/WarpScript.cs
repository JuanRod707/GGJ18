using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpScript : MonoBehaviour {

    public WarpScript WrpDestination;
    public Transform RecieverPoint;

    private List<string> canBeWarped = new List<string> { "Player", "Npcs", "Minion" };

    private void OnTriggerEnter(Collider other)
    {
        if (canBeWarped.IndexOf(other.tag) != -1)
        {
            other.GetComponentInParent<ObjectWarp>().Warp(WrpDestination.RecieverPoint.position);
        }
    }
}
