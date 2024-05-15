using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class GameManager
{
    public static MusicManager musicManager;

    public static float mainVolume = 1f;
    public static float musicVolume = 1f;
    public static float sfxVolume = 1f;

    public static bool inverted;
    public static int totalScore;
    public static bool playerDead;

    public static int wave;
    public static int killCount;

    public static int maxEnemyCount;
    public static int enemyCount;
    public static int spawnedEnemies;

    public static int sliceManWaveCount;
    public static int sliceManCounter;

    public static int birthdayBoyWaveCount;
    public static int birthdayBoyCounter;


    public static void StartGame()
    {
        wave = 1;
        sliceManWaveCount = 5;
        birthdayBoyWaveCount = 1;
        enemyCount = 6;
        maxEnemyCount = 40;
    }

    public static void NextWave()
    {
        sliceManWaveCount = Mathf.RoundToInt((sliceManWaveCount * 3) / 2);
        birthdayBoyWaveCount = Mathf.RoundToInt(((birthdayBoyWaveCount * 3) / 2) + 1);
        wave++;

        birthdayBoyCounter = 0;
        sliceManCounter = 0;
        enemyCount = sliceManWaveCount + birthdayBoyWaveCount;
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

        spawnedEnemies++;
    }

    public static void DecrementEnemyCounter()
    {
        enemyCount--;
        spawnedEnemies--;
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

    public static void ChangeMusicVolume()
    {
        musicManager.GetMusicSource().volume = musicManager.GetMaxVolume() * musicVolume * mainVolume;
    }

    public static void musicStop()
    {
        musicManager.GetMusicSource().Stop();
    }

    public static void musicReset()
    {
        musicManager.GetMusicSource().time = 0;
        musicManager.GetMusicSource().Play();
    }
    public static float SetSFXVolume(float volume)
    {
        return volume *mainVolume * sfxVolume;
    }
}
