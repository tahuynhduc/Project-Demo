using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public Transform enemyPrefab;
    public int numberOfEnemy;
    public Vector3 formationOffset;
    public FlyPath flyPath;
    public float speed;
    public float nextWaveDelay;
    public EnemyWave[] enemyWaves;
    private int currentWave;
    // Start is called before the first frame update
    void Start() => SpawnEnemyWave();
    private void SpawnEnemyWave()
    {
        var waveInfo = enemyWaves[currentWave];
        var startPosition = waveInfo.flyPath[0];
        for (int i = 0; i < waveInfo.numberOfEnemy; i++)
        {
            var enemy = Instantiate(waveInfo.enemyPrefab, startPosition,Quaternion.identity);
            var agent = enemy.GetComponent<FlyPathAgent>();
            agent.flyPath = waveInfo.flyPath;
            agent.flySpeed = waveInfo.speed;
            startPosition += waveInfo.formationOffset;
        }
        currentWave++;
        if (currentWave < enemyWaves.Length)
        {
            Invoke(nameof(SpawnEnemyWave), waveInfo.nextWaveDelay);
        }
    }
}
