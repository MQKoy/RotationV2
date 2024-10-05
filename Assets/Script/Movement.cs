using UnityEngine;

public class CircleOrbit : MonoBehaviour
{
    public Transform centerPoint; // Reference to the circle parent
    public float orbitSpeed = 50f; // Speed of orbit
    private bool isClockwise = true;

    void Update()
    {
        OrbitAround(); // Handle orbit movement

        // Toggle orbit direction on mouse click or space bar
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            ToggleOrbitDirection();
        }
    }

    void OrbitAround()
    {
        float direction = isClockwise ? -1f : 1f; // Determine direction
        transform.RotateAround(centerPoint.position, Vector3.forward, direction * orbitSpeed * Time.deltaTime);
    }

    void ToggleOrbitDirection()
    {
        isClockwise = !isClockwise; // Toggle direction
    }
}