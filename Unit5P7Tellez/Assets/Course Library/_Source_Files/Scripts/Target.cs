using UnityEngine;


public class Target : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody targetRb;
    private GameManger gamemanger;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;


    public int pointValue;
    public ParticleSystem explosionParticle;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gamemanger = GameObject.Find("GameManager").GetComponent<GameManger>();

        // Launch the object upward with a random force
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);

        // Give the object a random rotational spin
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        // Set a random starting position at the bottom of the screen
        transform.position =RandomSpawnPos();
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnMouseDown()
    {
        if(gamemanger.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gamemanger.UpdateScore(pointValue);
        }
            
    }
    private void OnTriggerEnter(Collider other) 
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad") && gamemanger.isGameActive)
        {
            gamemanger.UpdateLives(-1);
        }
       
            
        
    }
}
