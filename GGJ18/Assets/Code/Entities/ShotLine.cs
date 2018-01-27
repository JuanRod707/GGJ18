using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotLine : MonoBehaviour
{
    public float LifeSpan;

	void Update ()
	{
	    LifeSpan -= Time.deltaTime;
	    if (LifeSpan < 0)
	    {
	        Destroy(this.gameObject);
	    }
	}

    public void DrawLine(Vector3 origin, Vector3 destination)
    {
        var myLine = GetComponent<LineRenderer>();
        myLine.SetPosition(0, origin);
        myLine.SetPosition(1, destination);
    }
}
