using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    IEnumerator WaveStartDelay()
    {
        yield return new WaitForSeconds(5f);
        Enemy_Spawner.instance.StartSpawning();
    }
}
