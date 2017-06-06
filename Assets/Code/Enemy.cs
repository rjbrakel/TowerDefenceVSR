using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
    public float startHealth = 100;
	private float health;
	private Transform target;
	private int wavePointIndex = 0;
    public int value = 50;
    public GameObject deathEffect;

	public Image healthBar;

	void Start()
	{
		target = Waypoints.points[0];
		health = startHealth;
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

		if (Vector3.Distance (transform.position, target.position) <= 0.4f) 
		{
			GetNextWayPoint();
		}
	}

    public void TakeDamage(float amount)
    {
        health -= (amount / 2); 

		healthBar.fillAmount = health / startHealth;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStats.Money += value;

        GameObject effect = (GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(gameObject);    
    }

	private void GetNextWayPoint()
	{
		if (wavePointIndex >= Waypoints.points.Length - 1) 
		{
            EndPath();
			return;
		}

		wavePointIndex++;
		target = Waypoints.points [wavePointIndex];
	}

    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy (gameObject);   
    }
}
