using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingScoreManager : MonoBehaviour
{
    private string currentPlayerName;
    private List<int> turnScores = new List<int>(); 
    private int currentTurn; 
    private int maxTurns = 10; 

    public void StartNewGame(string playerName)
    {
        currentPlayerName = playerName;
        turnScores.Clear();
        currentTurn = 0;
    }

    public void CalculateScoreForTurn(int knockedDownPins)
    {
        turnScores.Add(knockedDownPins);

        if (currentTurn < maxTurns - 1 && knockedDownPins == 10)
        {
            currentTurn++;
        }
        else
        {
            // Move to the next turn.
            currentTurn++;
        }
    }

    public int CalculateTotalScore()
    {
        int totalScore = 0;

        for (int i = 0; i < turnScores.Count; i++)
        {
            int currentTurnScore = turnScores[i];

            if (i < maxTurns - 1)
            {
                if (currentTurnScore == 10)
                {
                    // Strike
                    totalScore += 10 + CalculateStrikeBonus(i);
                }
                else if (i < maxTurns - 2 && currentTurnScore + turnScores[i + 1] == 10)
                {
                    // Spare
                    totalScore += 10 + turnScores[i + 2];
                }
                else
                {
                    totalScore += currentTurnScore;
                }
            }
            else
            {
                totalScore += currentTurnScore;
            }
        }

        return totalScore;
    }

    private int CalculateStrikeBonus(int strikeIndex)
    {
        int bonus = 0;

        if (strikeIndex < turnScores.Count - 2)
        {
            bonus += turnScores[strikeIndex + 1];

            if (turnScores[strikeIndex + 1] == 10 && strikeIndex < turnScores.Count - 3)
            {
                bonus += turnScores[strikeIndex + 2];
            }
            else
            {
                bonus += turnScores[strikeIndex + 2];
            }
        }

        return bonus;
    }

    public int GetCurrentTurnIndex()
    {
        return currentTurn;
    }

    public List<int> GetTurnScores()
    {
        return turnScores;
    }
}

