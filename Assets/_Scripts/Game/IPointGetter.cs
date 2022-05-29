using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPointGetter
{
    //for player
   public void GetPoints(int points);

    //for bot
    public void BotTakePoints(int points);
}
