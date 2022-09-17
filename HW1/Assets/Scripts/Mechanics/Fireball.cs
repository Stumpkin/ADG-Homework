using UnityEngine;
using Platformer.Gameplay;
using Platformer.Mechanics;
using static Platformer.Core.Simulation;

public class Fireball : MonoBehaviour
{
    [SerializeField] private float timer;
    private BoxCollider2D hitbox;
    [SerializeField] private GameObject target;
    private float speed;

    // Start is called before the first frame update
    void Awake()
    {
        timer = 0;
        speed = 4f;
        hitbox = GetComponent<BoxCollider2D>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(gameObject.transform.position, target.GetComponent<PlayerController>().getLastKnownLocation(), 2 * Time.deltaTime);
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Schedule<PlayerDeath>();
        }
    }
}