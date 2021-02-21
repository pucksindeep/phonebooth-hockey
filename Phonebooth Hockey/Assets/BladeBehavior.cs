using UnityEngine;

public class BladeBehavior : MonoBehaviour
{

    public Rigidbody bladeRigidBody;
    public Transform blade;
    public Camera mainCamera;

    private Vector3 screenPoint;
    private Vector3 offset;

    public float bladeForce = .0001f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting. Position: ");
        // Debug.Log(blade.position.x);
        // Debug.Log(blade.position.y);
        // cameraZDistance = mainCamera.worldToScreenPoint(player.Position).z; // z axis of game object for screen view
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.position.z);
        // bladeRigidBody.velocity = (Input.mousePosition - blade.position).normalized * bladeForce;
    }

    // Called when the user clicks down on the collider
    void OnMouseDown() {



        screenPoint = mainCamera.WorldToScreenPoint(blade.position);
        offset = blade.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    // when I click and drag in the y direction from the camera's point of view, I need it to move in the z direction on the ground
    void OnMouseDrag() {
        // Debug.Log("we are dragging");
        // Debug.Log(Input.mousePosition.y);
        // Debug.Log(Input.mousePosition.x);

        Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(currentScreenPosition) + offset;
        blade.position = newWorldPosition;
        //player.position.y = Input.mousePosition.y;
    }
}
