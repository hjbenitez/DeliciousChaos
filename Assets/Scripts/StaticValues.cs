using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticValues
{
    public static bool inverted;
    public static int totalScore;
    public static bool playerDead;
    public static int wave;

    public static int enemyCount;
    public static int numberOfEnemies;

    public static void AddScore(int score)
    {
        totalScore += score;
    }
}
