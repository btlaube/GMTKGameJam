using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Plane daggingPlane;
    private Vector3 offset;
    private Camera mainCamera;

    void Start() {
        mainCamera = Camera.main;
    }

     void OnMouseDown() {
        daggingPlane = new Plane(mainCamera.transform.forward, transform.position);
        Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);

        float planeDistance;
        daggingPlane.Raycast(camRay, out planeDistance);
        offset = transform.position - camRay.GetPoint(planeDistance);
    }

    void OnMouseDrag() {
        Ray camRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        float planeDistance;
        daggingPlane.Raycast(camRay, out planeDistance);
        transform.position = camRay.GetPoint(planeDistance) + offset;
    }
}
