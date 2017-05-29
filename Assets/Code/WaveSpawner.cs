using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
	public Transform enemyPrefab;
	public float timeBetweenWaves = 19.99f;
	public Transform spawnPoint;
	public Text waveCountDownText;

	private float countDown = 2f;
	private int waveNumber = 0;

	void Update()
	{
		if (countDown <= 0f) 
		{
			StartCoroutine (SpawnWave ());
			countDown = timeBetweenWaves;
		}

		countDown -= Time.deltaTime;

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown);
	}

	IEnumerator SpawnWave()
	{
		waveNumber++;

		for (int x = 0; x < waveNumber; x++) 
		{
			SpawnEnemy ();
			yield return new WaitForSeconds (0.5f);
		}
	}

	void SpawnEnemy()
	{
		Instantiate (enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
