using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float Health = 100f;

	//UI
	[SerializeField] Slider SliderHealth;
	[SerializeField] Image SliderFill;
	[SerializeField] Gradient SliderFillColors;

	void Start ()
	{
		SliderHealth.maxValue = Health;
		SliderHealth.value = Health;
	}

	public void TakeDamage (float damage)
	{
		if (Health > damage) {
			Health -= damage;
		} else {
			Health = 0f;
			Die ();
		}
		UpdateSlider ();
	}

	void Die ()
	{
		Destroy (gameObject, .4f);
	}

	void UpdateSlider ()
	{
		SliderHealth.value = Health;
		//change fill color
		SliderFill.color = SliderFillColors.Evaluate (SliderHealth.normalizedValue);
	}
}
