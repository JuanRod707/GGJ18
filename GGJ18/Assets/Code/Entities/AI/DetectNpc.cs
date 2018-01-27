using UnityEngine;

public class DetectNpc : MonoBehaviour {

    public string RunToTag;

    private ChaseNpc chaseNpc;

	void Start () {
	    chaseNpc = GetComponentInParent<ChaseNpc>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(RunToTag))
        {
            chaseNpc.StartChasing(other.transform);
        }
    }
}
