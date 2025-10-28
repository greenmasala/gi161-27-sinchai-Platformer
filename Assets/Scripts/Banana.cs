using UnityEngine;

public class Banana : Weapon
{
    [SerializeField] private float speed;
    public override void Move()
    {
        float newX = transform.position.x + speed * Time.fixedDeltaTime; //current position + movement speed + amount of frames ran in-game
        float newY = transform.position.y; //projectile aint moving vertically so nuthin here
        Vector2 newPosition = new Vector2(newX, newY);
        transform.position = newPosition;
    }
    public override void OnHitWith(Character character)
    {
        if (character is Enemy)
            character.TakeDamage(this.Damage);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        speed = 4.0f * GetShootDirection();
        Damage = 30;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() //consistent movement compared to normal update.
    {
        Move();
    }
}
