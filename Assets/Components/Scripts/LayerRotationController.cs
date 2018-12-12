using UnityEngine;

public class LayerRotationController : MonoBehaviour
{
    public Transform[] layers;
    public float RotationSensitivity = 10;

    int selection;
    int lastSelection;

    public PlanetSelector selector;

    private float rotationX;

    Vector3 axis;

    private void Start()
    {
        rotationX = transform.rotation.eulerAngles.y;
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
            rotationX = Input.GetAxis("Mouse X") * RotationSensitivity;
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