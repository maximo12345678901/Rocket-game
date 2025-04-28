using UnityEngine;

public class ProceduralPlanet : MonoBehaviour
{
    [SerializeField] MeshFilter meshFilter;
    Vector3[] vertices;
    [SerializeField] float maxHeight;
    [SerializeField] float detail;
    [SerializeField] float height;
 
    float randomOffset;

    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
        randomOffset = Random.Range(0f, 100f);
        vertices = meshFilter.mesh.vertices;
        DisplaceVertices();
    }

    void Update()
    {
        FixZFighting();
    }

    void DisplaceVertices()
    {
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 currentVertex = vertices[i]; // Vector3 of the current vertex in the loop
            float angle = Mathf.Atan2(currentVertex.y, currentVertex.x); // Get the angle in radians (-π to π), a point around the unit circle
            float point = (angle * Mathf.PI) / (2 * Mathf.PI); // Normalize to a value between 0 and 1

            float elevation = Mathf.PerlinNoise(point * detail + randomOffset, 0f) * maxHeight;

            vertices[i] = currentVertex.normalized * (1f + elevation + height);
        }
        
        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.RecalculateNormals();
        meshFilter.mesh.RecalculateBounds();
    }

    void FixZFighting()
    {
        Vector3 direction = transform.position - mainCam.transform.position;
        direction.Normalize();
        meshFilter.gameObject.transform.position = transform.position + direction.normalized;
    }
}