using UnityEngine;

public class DragLayer : MonoBehaviour
{
    public bool currentlySelected = true;

    public float OrbitDiameter = 70f;
    public float DragSpeed = 180f;

    private Vector2 mouseXY;
    private new Camera camera;
    private Vector2 mouseStart;

    [HideInInspector]
    public bool Dragging { get; private set; }

    void Start()
    {
        OrbitDiameter = transform.localScale.y;
        camera = Camera.main;
    }

    void Update()
    {
        mouseXY = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            mouseStart = mouseXY;
        }

        if (currentlySelected && Input.GetMouseButton(0))
        {
            Dragging = true;
            var mouseDelta = mouseStart - mouseXY;

            Ray mouseOrbitRay = new Ray(camera.transform.position, camera.transform.forward * OrbitDiameter);
            Debug.DrawRay(camera.transform.position, camera.transform.forward * OrbitDiameter);

            Vector3 OrbitTarget = mouseOrbitRay.origin + mouseOrbitRay.direction * OrbitDiameter;

            var angle = Mathf.Atan2(OrbitTarget.z, OrbitTarget.x) * Mathf.Rad2Deg;

            var targetRot = Quaternion.AngleAxis(-angle, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, Time.deltaTime * DragSpeed);
        }

        if(Input.GetMouseButtonUp(0))
        {
            Dragging = false;
        }
    }
}