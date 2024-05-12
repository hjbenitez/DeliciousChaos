using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class StaticValues
{

    //big 5
    //small 4
    public static bool inverted;
    public static int totalScore;
    public static bool playerDead;

    public static int wave;
    public static int killCount;

    public static int maxEnemyCount;
    public static int enemyCount;

    public static int sliceManWaveCount;
    public static int sliceManCounter;

    public static int birthdayBoyWaveCount;
    public static int birthdayBoyCounter;


    public static void StartGame()
    {
        wave = 1;
        sliceManWaveCount = 5;
        birthdayBoyWaveCount = 1;
        maxEnemyCount = 40;
    }

    public static void NextWave()
    {
        sliceManWaveCount = Mathf.RoundToInt((sliceManWaveCount * 3) / 2);
        birthdayBoyWaveCount = Mathf.RoundToInt((birthdayBoyWaveCount * 3) / 2);
        wave++;

        birthdayBoyCounter = 0;
        sliceManCounter = 0;
        enemyCount = 0;
    }

    public static void AddScore(int score)
    {
        totalScore += score;
    }

    public static void IncremenentEnemyCounter(int layer)
    {
        if(layer == 11) //birthday boy
        {
            birthdayBoyCounter++;
        }

        else //slice man 
        {
            sliceManCounter++;
        }

        enemyCount++;
    }

    public static void DecrementEnemyCounter()
    {
        enemyCount--;
    }

    public static bool CheckLayerCount(int layer)
    {
        if (layer == 11) //birthday boy
        {
            return birthdayBoyCounter < birthdayBoyWaveCount;
        }

        else //slice man
        {
            return sliceManCounter < sliceManWaveCount;
        }
    }
}
