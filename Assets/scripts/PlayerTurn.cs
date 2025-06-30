using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerTurn
{
    public static bool Player1 = true;

    
    public static void TurnChange ()
    {
        Player1 = !Player1;

    }

    

}
