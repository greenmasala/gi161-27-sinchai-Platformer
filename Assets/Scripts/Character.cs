using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public abstract class Character : MonoBehaviour
{
    private float maxHealth; 
    public float MaxHealth
    {
        get { return maxHealth; }
        set { maxHealth = value < 0 ? 0 : value; }
    }

    private int health;
    public int Health
    {
        get { return health; }
        set { health = value < 0 ? 0 : value; }
    }

    protected Animator anim;
    protected Rigidbody2D rb;
    [SerializeField] protected Image HealthBar;

    public void Init(int startingHealth)
    {
        Health = startingHealth;
        maxHealth = startingHealth;
        Debug.Log($"{this.name}'s HP: {this.Health}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); //getting component to run anims
        HealthBar.fillAmount = this.Health / this.MaxHealth;

    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log($"{this.name} took {damage} damage. Current health: {Health}");
        HealthBar.fillAmount = this.Health / this.MaxHealth;

        IsDead();
    }

    public bool IsDead()
    {
        if (Health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else { return false; }
    }
}
