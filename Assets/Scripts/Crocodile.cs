using UnityEngine;

public class Crocodile : Enemy
{
    [SerializeField] float attackRange;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Init(60);
        DamageHit = 30;

        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Behavior();
    }
    public override void Behavior()
    {
        //find distance between crocodile and player
        Vector2 distance = transform.position - player.transform.position;

        if (distance.magnitude <= attackRange) //magnitude = only get distance, no vectors
        {
            Debug.Log($"{player.name} is in the {this.name}'s attack range!");
            Shoot();
        }
    }

    public void Shoot()
    {
        Debug.Log($"get stoned");
    }
}
