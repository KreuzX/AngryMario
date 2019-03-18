using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NumberOfCoinsToStartWave
{
    public int firstWave;
    public int SecondWave;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public GameObject coin;
    public NumberOfCoinsToStartWave _numberOfCoinsToStartWave;

    private int coinCount;
    

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != null) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    /// <summary>
    /// 유저의 Coin을 증가시키고 해당 position에 Coin을 생성시킵니다.
    /// </summary>
    /// <param name="positionToCreateCoin"></param>
    public void AddCoin(Transform positionToCreateCoin)
    {
        Instantiate(coin, positionToCreateCoin.position, Quaternion.identity);
    }


}
