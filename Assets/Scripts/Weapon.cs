using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int Damage;
    public IShootable Shooter;

    public abstract void Move();
    public abstract void OnHitWith(Character character);

    public void InitWeapon(int newDamage, IShootable newShooter)
    {
        Damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x; //subtract shootpoint location from parent location. if negative then left, if positive then right

        if (value > 0) 
            return 1; //right
            else return - 1; //left
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Character character = other.GetComponent<Character>(); //check if other (collided object) is a character
        if (character != null) //if collided object has character script
        {
            OnHitWith(character);
            Destroy(this.gameObject, 5f); //destroy projectile after 5 seconds
        }
    }
}

