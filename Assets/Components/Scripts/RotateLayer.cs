using UnityEngine;

public class RotateLayer : MonoBehaviour
{
    private float rotationX;
    private float rotationY;
    private float rotationSpeed = 10;

    Vector3 axis;

    private void Start()
    {
        rotationX = transform.rotation.eulerAngles.y;
        rotationY = transform.rotation.eulerAngles.x;
        axis = transform.up;
    }

    private void Update()
    {
        if (Input.mousePosition.x == 0 ||
            Input.mousePosition.y == 0 ||
            Input.mousePosition.x >= Screen.width - 1 ||
            Input.mousePosition.y >= Screen.height - 1)
            return;

        if(Input.GetMouseButtonDown(0))
        {

        }

        if (Input.GetMouseButton(0))
        {
            rotationX += Input.GetAxis("Mouse X") * rotationSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            RotateView();
        }

        Debug.DrawLine(Vector3.zero, axis * 10);
    }

    public void RotateView()
    {
        transform.rotation = Quaternion.AngleAxis(rotationX, axis); //(Quaternion.AngleAxis(rotationX, Vector3.up) * Quaternion.AngleAxis(rotationY, Vector3.right));
    }
}