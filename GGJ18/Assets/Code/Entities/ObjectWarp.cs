using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectWarp : MonoBehaviour {

    public void Warp(Vector3 position)
    {
        this.transform.position = position;
    }
}
