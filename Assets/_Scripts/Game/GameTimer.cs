using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{

    [SerializeField ]public TextMeshProUGUI txt_timer;

    float countdownTimeStart = 90.0f;
    bool startTimer = false;

    void Update()
    {
        if (startTimer)
        {
            if (countdownTimeStart > 0)
            {
                countdownTimeStart -= Time.deltaTime;
            }

            double b = System.Math.Round(countdownTimeStart, 0);

            txt_timer.text = b.ToString();
            if (countdownTimeStart < 0)
            {
                GameManager.Instance.GameFinish();
                txt_timer.text = "00";
            }
        }
    }

    public void StartTimer() 
    {
        Debug.Log("Im here");
        startTimer = true;
    }
}
