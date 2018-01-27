using UnityEngine;

public class DetectProximity : MonoBehaviour {

    public string RunFromTag;

    private NpcRunFromDanger runFromdanger;

	void Start () {
        runFromdanger = GetComponentInParent<NpcRunFromDanger>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(RunFromTag))
        {
            runFromdanger.StartRunning(other.transform.position);
        }
    }
}
