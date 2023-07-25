using UnityEngine;

namespace Test
{
    public class RotationCamera : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 90f;
        
        
        private Vector2 _delta;
        private Vector2 _mouseLastPosition;
        
        private void Update()
        {
            CheckTouch();
            
            Rotate();
        }

        private void CheckTouch()
        {
            if (Input.touchCount == 0 || Input.touchCount >= 2)
            {
                _delta = Vector2.zero;
			
                return;
            }
		
            Touch touch = Input.GetTouch(0);

            _delta = touch.deltaPosition.normalized;
        }

        
        private void CheckMouse()
        {
            if (Input.GetMouseButton(0))
            {
                _delta = (Vector2)Input.mousePosition - _mouseLastPosition;
			
                _mouseLastPosition = Input.mousePosition;
                _delta.x = -_delta.x;
                _delta.Normalize();

                return;
            }

            _delta = Vector2.zero;
        }
        
        private void Rotate()
        {
            float xRotation = _delta.x * Time.deltaTime * _rotationSpeed;
            float yRotation = _delta.y * Time.deltaTime * _rotationSpeed;

            transform.RotateAround(Vector3.zero, Vector3.up, xRotation);
            transform.RotateAround(Vector3.zero, Vector3.right, yRotation);
        }
    }
}