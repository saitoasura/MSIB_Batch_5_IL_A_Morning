using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : CoinTrigger
{
    protected override void Action()
    {
        base.Action();
        GameManager.Instance.OnTrapsEnter?.Invoke();
        Destroy(gameObject);
    }
}
