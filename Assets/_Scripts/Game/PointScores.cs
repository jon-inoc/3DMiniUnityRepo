using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScores : MonoBehaviour
{
    [SerializeField] private int score;

    private void OnTriggerEnter(Collider other)
    {
        IPointGetter pointGetter = other.GetComponent<IPointGetter>();

        if (pointGetter != null) 
        {
            pointGetter.GetPoints(score);
            Destroy(this.gameObject);
        }
    }
}
