using UnityEngine;

public class Crocodile : Enemy, IShootable
{
    [SerializeField] float attackRange;
    public Player player;

    [field: SerializeField] public GameObject Bullet { get; set ; }
    [field: SerializeField] public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Init(60);
        DamageHit = 30; //collision damage

        //attack range and target
        attackRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();

        WaitTime = 0.0f;
        ReloadTime = 0.01f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime;
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
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot"); //call shoot anim
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            if (rock != null)
            {
                rock.InitWeapon(30, this);
            }
            WaitTime = 0.0f; //reset waittime
        }
    }
}
