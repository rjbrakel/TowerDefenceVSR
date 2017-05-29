﻿using UnityEngine;

public class BuildManager : MonoBehaviour {

	public static BuildManager instance;
	public GameObject standardTurretPrefab;
	public GameObject missileLauncherPrefab;

	private TurretBluePrint turretToBuild;

	void Awake()
	{
		if (instance != null) 
		{
			Debug.LogError ("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}   

    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.Money <= turretToBuild.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        Debug.Log("Turret build! Money left:" + PlayerStats.Money);

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);       
        node.turret = turret;
    }
}
