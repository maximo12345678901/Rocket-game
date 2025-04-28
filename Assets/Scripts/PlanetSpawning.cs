using UnityEngine;
public class PlanetSpawning : MonoBehaviour
{
    [Header("Planet spawning settings")]
    [SerializeField] GameObject planetPrefab;
    [SerializeField] float maxDistance;
    [SerializeField] int numberOfPlanets;
    [SerializeField] Transform player;

    [Header("Planet settings")]
    [SerializeField] int minPlanetSize = 10;
    [SerializeField] int maxPlanetSize = 31;
    [SerializeField] float maxPlanetTurningSpeed;
    [SerializeField] Color[] colorPresets;

    GameObject[] planets;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnPlanets();
        planets = GameObject.FindGameObjectsWithTag("Planet");
    }

    // Update is called once per frame
    void Update()
    {
        if (planets == null) {return;}
        LoopPlanets();
    }

    void LoopPlanets()
    {
        foreach(GameObject planet in planets)
        {
            Vector2 distance = planet.transform.position - player.position;
            if (distance.magnitude > maxDistance)
            {
                planet.transform.position = (Vector2)player.position - distance.normalized * maxDistance;
            }
        }
    }

    void SpawnPlanets()
    {
        for (int i = 0; i < numberOfPlanets; i++)
        {
            // Spawning
            float randomAngle = Random.Range(0f, 360f);
            Vector2 positionAroundCircle = new (Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
            positionAroundCircle *= maxDistance;
            Vector2 randomPosition = positionAroundCircle * Random.Range(0.1f, 1f);

            GameObject spawnedPlanet = Instantiate(planetPrefab, randomPosition, Quaternion.Euler(180f, 0f, 0f), transform);

            // Spinning
            spawnedPlanet.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-maxPlanetTurningSpeed, maxPlanetTurningSpeed);

            // Size
            int planetSize = Random.Range(minPlanetSize, maxPlanetSize); 
            spawnedPlanet.transform.localScale = new (
                planetSize,
                planetSize,
                1
            );
            
            // Color
            Color foregroundColor = colorPresets[Random.Range(0, colorPresets.Length)];
            Color backgroundColor = Color.Lerp(foregroundColor, Color.black, 0.4f);
            spawnedPlanet.GetComponent<MeshRenderer>().material.color = foregroundColor;
            spawnedPlanet.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = backgroundColor;
        }
    }
}
