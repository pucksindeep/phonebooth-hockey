using UnityEngine;

public class BladeBehavior : MonoBehaviour
{

    public Rigidbody bladeRigidBody;
    public Transform blade;
    public Camera mainCamera;

    private Vector3 downVelcity = new Vector3(0.0f, -9.8f, 0.0f);

    private Vector3 bladeScreenPoint;
    private Vector3 offset;

    private Vector3 previousBladeScreenPosition;

    private Vector3 mouseDragForce;

    public float bladeForce = .0001f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting. Position: ");
    }

    void FixedUpdate() {

        Debug.Log(offset);

        // need to change mouseDragForce to normal force if user is not clicking and dragging
        if (Input.GetMouseButton(0)) {
            // Debug.Log("Fixed update and clicking down");
            bladeRigidBody.velocity = mouseDragForce * 0.1f;
            mouseDragForce = new Vector3(0, 0, 0);
        } else {
            // Debug.Log("Fixed update and NOT CLICKING DOWN");
            // bladeRigidBody.velocity = mouseDragForce * 0f;
            bladeRigidBody.velocity = new Vector3(0.0f, -9.8f, 0.0f);
            // bladeRigidBody.useGravity = false;
            // bladeRigidBody.isKinematic = false;
        }

        // bladeRigidBody.velocity = mouseDragForce * 0.1f;
    }

    // Called when the user clicks down on the collider
    void OnMouseDown() {

        bladeScreenPoint = mainCamera.WorldToScreenPoint(blade.position);
        offset = blade.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, bladeScreenPoint.z));
        previousBladeScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, bladeScreenPoint.z);

    }

    // when I click and drag in the y direction from the camera's point of view, I need it to move in the z direction on the ground
    void OnMouseDrag() {

        Vector3 currentBladeScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, bladeScreenPoint.z);

        if (currentBladeScreenPosition.x > previousBladeScreenPosition.x) {
            // Debug.Log("Going RIGHT");
        } else if (currentBladeScreenPosition.x < previousBladeScreenPosition.x) {
            // Debug.Log("Going LEFT");
        }

        mouseDragForce = currentBladeScreenPosition - previousBladeScreenPosition;
        previousBladeScreenPosition = currentBladeScreenPosition;
    }
}
