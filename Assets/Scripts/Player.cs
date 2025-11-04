using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character, IShootable
{
    [field: SerializeField] public GameObject Bullet { get ; set ; }
    [field: SerializeField] public Transform ShootPoint { get; set; } //serializefield to be able to define what these are directly in the viewport
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Init(200);
        ReloadTime = 0.01f;
        WaitTime = 0.0f;
    }

    private void FixedUpdate() // loop every 0.02 secs
    {
        WaitTime = Time.fixedDeltaTime; // = 0 + 0.02 + 0.02... 
    }

    public void OnHitWith(Enemy enemy) //method to allow for different results depending on damage source
    {
        TakeDamage(enemy.DamageHit);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (enemy != null) 
        {
           OnHitWith(enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }

    public void Shoot()
    {
       if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime) //if waittime equals reload time, then shoot
        {
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Banana banana = bullet.GetComponent<Banana>();
            if (banana != null)
            {
                banana.InitWeapon(20, this);
            }
            WaitTime = 0.0f; //reset waittime
        }
    }
}
