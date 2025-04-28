using UnityEngine;
public class PlanetSpawning : MonoBehaviour
{
    [SerializeField] GameObject planetPrefab;
    [SerializeField] float maxDistance;
    [SerializeField] float maxPlanetTurningSpeed;
    [SerializeField] int numberOfPlanets;

    [SerializeField] int minPlanetSize = 10;
    [SerializeField] int maxPlanetSize = 31;
    GameObject[] planets;
    [SerializeField] Transform player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlanets();
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        LoopPlanets();
    }

    void LoopPlanets()
    {
        foreach(GameObject planet in planets)
        {
            Vector2 distance = planet.transform.position - player.position;
            if (distance.magnitude > maxDistance)
            {
                planet.transform.position = (Vector2) player.position - distance;
            }
        }
    }

    void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            float randomAngle = Random.Range(0f, 360f);
            Vector2 positionAroundCircle = new (Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            positionAroundCircle *= maxDistance;
            Vector2 randomPosition = positionAroundCircle * Random.Range(0.1f, 1f);

            GameObject spawnedPlanet = Instantiate(planetPrefab, randomPosition, Quaternion.identity);

            spawnedPlanet.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-maxPlanetTurningSpeed, maxPlanetTurningSpeed);

            int planetSize = Random.Range(minPlanetSize, maxPlanetSize); 
            spawnedPlanet.transform.localScale = new (
                planetSize,
                planetSize,
                1
            );
        }
    }
}
