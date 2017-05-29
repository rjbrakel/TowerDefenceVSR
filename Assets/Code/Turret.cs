﻿using UnityEngine;

public class Turret : MonoBehaviour 
{
	private Transform target;

	[Header("Attributes")]
	private float fireCountDown = 0f;
	public float range = 15f;
	public float fireRate = 1f;

	[Header("Unity Setup Fields")]
	public Transform partToRotate;
	public float turnSpeed = 10f;

	public GameObject bulletPrefab;
	public Transform firePoint;

	void Start()
	{
		InvokeRepeating ("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;

		foreach (GameObject enemy in enemies) 
		{
			float distance = Vector3.Distance (transform.position, enemy.transform.position);
			if (distance < shortestDistance) 
			{
				shortestDistance = distance;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range) {
			target = nearestEnemy.transform;
		} 
		else 
		{
			target = null;
		}
	}

	void Update()
	{
		if (target == null)
			return;

		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation (dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler (0f, rotation.y, 0f);

		if (fireCountDown <= 0f) 
		{
			Shoot ();
			fireCountDown = 1f / fireRate;
		}

		fireCountDown -= Time.deltaTime;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (transform.position, range);
	}

	void Shoot()
	{
		GameObject bulletGO = (GameObject) Instantiate (bulletPrefab, firePoint.position, firePoint.rotation);
		Bullet bullet = bulletGO.GetComponent<Bullet> ();

		if (bullet != null) 
			bullet.Seek (target);
	}
}
