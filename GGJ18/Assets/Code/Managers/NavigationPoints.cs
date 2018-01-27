using System.Linq;
using Assets.Code.Helpers;
using UnityEngine;

public class NavigationPoints : MonoBehaviour
{
    public string NavPointsTag;

    private Transform[] navigationNodes;
    
    public Vector3 GetRandomPointPosition { get { return navigationNodes != null ? navigationNodes.PickOne().position : Vector3.zero; } }

    void Start()
    {
        navigationNodes = this.GetComponentsInChildren<Transform>().Where(x => x.CompareTag(NavPointsTag)).ToArray();
    }
}
