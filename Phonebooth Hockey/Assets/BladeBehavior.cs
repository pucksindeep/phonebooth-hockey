using UnityEngine;

public class BladeBehavior : MonoBehaviour
{

    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting. Position: ");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(player.position.z);
    }

    // when I click and drag in the y direction from the camera's point of view, I need it to move in the z direction on the ground
    void OnMouseDrag() {
        Debug.Log("we are dragging");
        Debug.Log(Input.mousePosition.z);
        Debug.Log(Input.mousePosition.x);
    }
}
