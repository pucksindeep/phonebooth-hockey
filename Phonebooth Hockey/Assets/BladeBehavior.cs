using UnityEngine;

public class BladeBehavior : MonoBehaviour
{

    public Rigidbody bladeRigidBody;
    public Transform blade;
    public Camera mainCamera;

    private Vector3 screenPoint;
    private Vector3 offset;

    private Vector3 previousMousePosition;

    private Vector3 mouseDragForce;

    public float bladeForce = .0001f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting. Position: ");
    }

    void FixedUpdate() {

        // need to change mouseDragForce to normal force if user is not clicking and dragging
        if (Input.GetMouseButton(0)) {
            Debug.Log("Fixed update and clicking down");
            bladeRigidBody.velocity = mouseDragForce * 0.1f;
        } else {
            Debug.Log("Fixed update and NOT CLICKING DOWN");
            bladeRigidBody.velocity = mouseDragForce * 0f;
        }

        // bladeRigidBody.velocity = mouseDragForce * 0.1f;
    }

    // Called when the user clicks down on the collider
    void OnMouseDown() {

        screenPoint = mainCamera.WorldToScreenPoint(blade.position);
        previousMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

    }

    // when I click and drag in the y direction from the camera's point of view, I need it to move in the z direction on the ground
    void OnMouseDrag() {

        Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        mouseDragForce = currentScreenPosition - previousMousePosition;
        previousMousePosition = currentScreenPosition;
    }
}
