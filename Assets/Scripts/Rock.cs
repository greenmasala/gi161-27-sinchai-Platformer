using UnityEngine;

public class Rock : Weapon
{
    public Rigidbody2D rb;
    public Vector2 force; //use to throw rock, basically were using physics to move this shit

    public override void Move()
    {
        rb.AddForce(force);
    }

    public override void OnHitWith(Character obj)
    {
        if (obj is Player)
            obj.TakeDamage(this.Damage);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Damage = 40;
        force = new Vector2(GetShootDirection() * 100, 400); //vector2 (x, y)
        Move(); //add force to rock immediately upon intitialization
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
