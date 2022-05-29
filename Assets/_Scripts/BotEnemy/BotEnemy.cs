using System.Collections;
using UnityEngine;

public class BotEnemy : MonoBehaviour
{
    [SerializeField] private int _pointsToTake;

    bool takePointsCooldown = false;
    private void OnTriggerEnter(Collider other)
    {
        IPointGetter pointGetter = other.GetComponent<IPointGetter>();

        if (pointGetter != null && !takePointsCooldown) 
        {
            takePointsCooldown = true;
            pointGetter.BotTakePoints(_pointsToTake);
            StartCoroutine("StartDmgCD", 0.3f);
        }
    }

    IEnumerator StartDmgCD() 
    {
        yield return new WaitForSeconds(0.5f);
        takePointsCooldown = false;
    }

}
