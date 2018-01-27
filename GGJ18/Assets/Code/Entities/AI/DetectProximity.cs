using Assets.Code.Entities;
using UnityEngine;

public class DetectProximity : MonoBehaviour {

    public string MinionTag;

    private ReactToMinion reactToMinion;

	void Start () {
	    reactToMinion = GetComponentInParent<ReactToMinion>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MinionTag))
        {
            reactToMinion.React(other.transform);
        }
    }
}
