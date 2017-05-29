using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

	public Color hoverColor;
    public Color noMoneyColor;
	public Vector3 positionOffset;

    [Header("Optional")]
    public GameObject turret;

	private Color startColor;
	private Renderer rend;
	private BuildManager buildManager;

	void Start()
	{
		rend = GetComponent<Renderer> ();
		startColor = rend.material.color;
		buildManager = BuildManager.instance;
	}

	void OnMouseDown()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

        if (!buildManager.CanBuild)
			return;

		if (turret != null) 
		{
			Debug.Log ("Can't build there!");
			return;
		}

        buildManager.BuildTurretOn(this);
	}

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

	void OnMouseEnter()
	{
		if (EventSystem.current.IsPointerOverGameObject ())
			return;

        if (!buildManager.CanBuild)
			return;

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = noMoneyColor;   
        }
	}

	void OnMouseExit()
	{
		rend.material.color = startColor;
	}
}
