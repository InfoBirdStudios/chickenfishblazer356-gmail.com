using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState {Start, PlayerTurn, EnemyTurn, Won, Lost}

public class TurnManager : MonoBehaviour
{
    public BattleState battleState;
    public Unit unitSelected;

    public int playerTurn = 1;

    public void ResetTiles()
    {
        foreach (TileScript tile in FindObjectsOfType<TileScript>())
        {
            tile.Reset();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchTurn();
        }
    }
    void SwitchTurn()
    {
        if (playerTurn == 1)
        {
            playerTurn = 2;

        }
        else if (playerTurn == 2)
        {
            playerTurn = 1;
        }

        if (unitSelected != null)
        {
            unitSelected.selected = false;
            unitSelected = null;

        }

        ResetTiles();



        foreach (Unit unit in FindObjectsOfType<Unit>())
        {
            unit.hasWalked = false;
            unit.smoke.SetActive(false);
            unit.hasAttacked = false;
        }
    }

    
}
