using Assets.Code.Entities;
using UnityEngine;

public class DetectProximity : MonoBehaviour {

    public string MinionTag;
    public string PlayerTag;

    private ReactToMinion reactToMinion;

	void Start () {
	    reactToMinion = GetComponentInParent<ReactToMinion>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(MinionTag) || other.CompareTag(PlayerTag))
        {
            reactToMinion.React(other.transform);
        }
    }
}
