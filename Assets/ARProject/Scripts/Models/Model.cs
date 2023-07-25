using UnityEngine;

public class Model : MonoBehaviour
{
    [Header("Size Parameters")]
    [SerializeField] private Vector3 _startScale;

    [Header("Rotation")]
    [SerializeField] private Vector3 _startRotation = Vector3.zero;
    [SerializeField] private float _rotationSpeed = 10f;
    
    public void MultiplyScale(float scale)
    {
        transform.localScale = _startScale * scale;

        UseStartRotation();
    }

    private void UseStartRotation()
    {
	    transform.rotation = Quaternion.Euler(_startRotation);
    }

	public void Rotate(Vector2 delta)
	{
		float xRotation = delta.x * Time.deltaTime * _rotationSpeed;
		float yRotation = delta.y * Time.deltaTime * _rotationSpeed;

		transform.RotateAround(transform.position, Vector3.up, -xRotation);
		transform.RotateAround(transform.position, Vector3.right, yRotation);
	}
}
