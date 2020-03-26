using UnityEngine;

public class CameraRotator : MonoBehaviour
{
	[SerializeField] float RotationSpeed = 8f;

	void LateUpdate ()
	{
		transform.Rotate (Vector3.up * RotationSpeed * Time.deltaTime);
	}
}
