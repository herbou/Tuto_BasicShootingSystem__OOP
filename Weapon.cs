using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
	public string Name;
	public float Damage;
	public int Bullets;

	private int defaultBullets;
	//UI

	[SerializeField] Text TextWeaponName;
	[SerializeField] Slider SliderWeaponBullets;

	void Start ()
	{
		defaultBullets = Bullets;
		SliderWeaponBullets.maxValue = defaultBullets;
		SliderWeaponBullets.value = defaultBullets;
		TextWeaponName.text = Name;
	}

	public void PerformShot ()
	{
		if (Bullets > 0) {
			Bullets--;
			UpdateSlider ();
		}
	}

	public void RechargeWeapon ()
	{
		if (Bullets == 0) {
			Bullets = defaultBullets;
			UpdateSlider ();
		}
	}

	public bool HasEnoughBullets ()
	{
		return Bullets > 0;
	}

	void UpdateSlider ()
	{
		SliderWeaponBullets.value = Bullets;
	}
}
