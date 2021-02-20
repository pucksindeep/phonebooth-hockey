using UnityEngine;

public class BladeBehavior : MonoBehaviour
{

    public Transform player;

    public Camera mainCamera;
    private float cameraZDistance;

    private Vector3 screenPoint;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting. Position: ");
        Debug.Log(player.position.x);
        Debug.Log(player.position.y);
        // cameraZDistance = mainCamera.worldToScreenPoint(player.Position).z; // z axis of game object for screen view
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.position.z);
    }

    void OnMouseDown() {
        screenPoint = mainCamera.WorldToScreenPoint(player.position);
        offset = player.position - mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

    }

    // when I click and drag in the y direction from the camera's point of view, I need it to move in the z direction on the ground
    void OnMouseDrag() {
        Debug.Log("we are dragging");
        Debug.Log(Input.mousePosition.y);
        Debug.Log(Input.mousePosition.x);

        Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 newWorldPosition = mainCamera.ScreenToWorldPoint(currentScreenPosition) + offset;
        player.position = newWorldPosition;
        //player.position.y = Input.mousePosition.y;
    }
}
