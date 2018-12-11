using UnityEngine;

public class RotateLayer : MonoBehaviour
{
    public Transform[] layers;
    int selection;
    int lastSelection;

    public PlanetSelector selector;

    private float rotationX;
    private float rotationY;
    private float rotationSpeed = 10;

    Vector3 axis;

    private void Start()
    {
        rotationX = transform.rotation.eulerAngles.y;
        rotationY = transform.rotation.eulerAngles.x;
        axis = layers[selection].transform.up;
    }

    private void Update()
    {
        selection = selector.currentSelection;
        Debug.DrawRay(Vector3.zero, axis * 10);
        axis = layers[selection].transform.up;

        if (Input.mousePosition.x == 0 ||
            Input.mousePosition.y == 0 ||
            Input.mousePosition.x >= Screen.width - 1 ||
            Input.mousePosition.y >= Screen.height - 1)
            return;

        if(Input.GetMouseButtonDown(0))
        {
            if(selection != lastSelection)
            {
                rotationX = 0;
            }
        }

        if (Input.GetMouseButton(0))
        {
            rotationX = Input.GetAxis("Mouse X") * rotationSpeed;
            RotateView();
        }

        if(Input.GetMouseButtonUp(0))
        {
            lastSelection = selection;
        }
    }

    public void RotateView()
    {
        layers[selection].Rotate(axis, rotationX, Space.World); // = Quaternion.AngleAxis(angle, axis); //(Quaternion.AngleAxis(rotationX, Vector3.up) * Quaternion.AngleAxis(rotationY, Vector3.right));
    }
}