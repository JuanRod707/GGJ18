using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForceRotation : MonoBehaviour
{
    void Update()
    {
        this.transform.rotation = Quaternion.identity;
    }
}
