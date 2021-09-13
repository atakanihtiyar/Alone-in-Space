using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Upgraded version of <c>MonoBehaviour</c> with static references to managers 
/// </summary>
public class UpgradedMonoBehaviour : MonoBehaviour
{
    protected static GameStateController gameStateController;
    protected static MovementManager movementManager;
    protected static CoinController coinController;
    protected static ThemeManager themeManager;
    protected static Notify notify;

    protected virtual void Awake()
    {
        gameStateController = GameStateController.Instance;
        movementManager = MovementManager.Instance;
        coinController = CoinController.Instance;
        themeManager = ThemeManager.Instance;
        notify = Notify.Instance;
    }
}
