using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaDamageEffect : MonoBehaviour
{
    public List<GameObject> EntitiesInsideTrigger;
    public float SecondsBeforeEffectStarts = 1;
    public AudioSource SpecialSfx;

    private void Start()
    {
        EntitiesInsideTrigger = new List<GameObject>();
        StartCoroutine(ActivateEffect());
    }

    public IEnumerator ActivateEffect()
    {
        yield return new WaitForSeconds(SecondsBeforeEffectStarts);
        SpecialSfx.Play();
        EntitiesInsideTrigger.RemoveAll(x => x == null);
        foreach (var entity in EntitiesInsideTrigger)
        {
            if (!entity.CompareTag(Constants.tagPlayer) &&
                !entity.transform.parent.CompareTag(Constants.tagPlayer))
            {
                Debug.Log(string.Format("Tag is: {0}", entity.tag));
                // TODO handle npc and minion cases.
                Destroy(entity);
            }
        }
        EntitiesInsideTrigger.Clear();
    }

    private void OnTriggerEnter(Collider other)
    {
        EntitiesInsideTrigger.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        EntitiesInsideTrigger.Remove(other.gameObject);
    }
}