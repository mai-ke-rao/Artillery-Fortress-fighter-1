using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    
    public static int fireBall = 1;
    public static int debounce = 3;
    public static bool debounceActive = false;
    public static int gold = 100;


    public static int useFireBall()
    {
        fireBall = fireBall - 1;
        return fireBall;
    }

    public static bool useDebounce()
    {
        debounce = debounce - 1;
        debounceActive = true;
        return debounceActive;
    }

    public static int useSiegeWeapon()
    {
        gold = gold - 80;
        return gold;
    }

    public static int newTurn()
    {
        gold = gold + 15;
        return gold > 100? 100:gold;
    }

    public static void deactivateDebounce()
    {
        debounceActive = false;
    }

}
