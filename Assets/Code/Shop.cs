 using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
	public TurretBluePrint laserBeamer;

	BuildManager buildManager;

	void Start()
	{
		buildManager = BuildManager.instance;
	}

    public void SelectStandardTurret()
	{
		Debug.Log ("Standard turret selected");
        buildManager.SelectTurretToBuild (standardTurret);
	}

	public void SelectMissileLauncher()
	{
		Debug.Log ("Missle launcher selected");
        buildManager.SelectTurretToBuild (missileLauncher);
	}

	public void SelectLaserBeamer()
	{
		Debug.Log ("Laser Beamer Selected");
		buildManager.SelectTurretToBuild (laserBeamer);
	}
}
