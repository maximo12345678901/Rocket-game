using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] Transform pointer;
    GameObject[] planets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (planets == null || planets.Length == 0)
        {
            planets = GameObject.FindGameObjectsWithTag("Planet");
            return;
        }

        if (ClosestObject() != null)
        {
            OrientPointer();
        }
    }

    void OrientPointer()
    {
        Vector2 direction = ClosestObject().transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        pointer.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }

    GameObject ClosestObject()
    {
        if (planets == null || planets.Length == 0)
        return null;

        GameObject closestObject = planets[0];
        float smallestDistance = Vector2.Distance(transform.position, closestObject.transform.position);
        
        foreach(GameObject planet in planets)
        {
            float distance = Vector2.Distance(planet.transform.position, transform.position);

            if (distance < smallestDistance)
            {
                smallestDistance = distance;
                closestObject = planet;
            }
        }

        return closestObject;
    }
}