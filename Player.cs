using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] LayerMask layerMask;
	Camera cam;

	public Weapon ActiveWeapon;

	void Start ()
	{
		cam = Camera.main;
	}

	void Update ()
	{
		if (Input.GetMouseButtonUp (0)) {
			PrepareWeapon ();
		}
		if (Input.GetMouseButtonUp (1)) {
			ActiveWeapon.RechargeWeapon ();
		}
	}

	void PrepareWeapon ()
	{
		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay (Input.mousePosition);

		Enemy targetEnemy = null;

		if (Physics.Raycast (ray, out hit, float.PositiveInfinity, layerMask)) {
			//ray hits somthing with collider
			if (hit.collider.tag.Equals ("enemy")) {
				//ray hits enemy
				targetEnemy = hit.collider.GetComponent <Enemy> ();
			}
		}

		if (targetEnemy != null && ActiveWeapon.HasEnoughBullets ()) {
			//shot
			targetEnemy.TakeDamage (ActiveWeapon.Damage);
		}

		//shot anyway
		ActiveWeapon.PerformShot ();
	}
}
