using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity; //show private variable in unity instead of having to make it public
    public Transform[] MovePoints;
    
    void Start()
    {
        base.Init(30);
        DamageHit = 20;

        velocity = new Vector2(-1.0f, 0.0f); //speed of ant. -1 is going to the left
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Behavior();
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); //move from one position to another. (rb.position is position of ant) DeltaTime is basically making it move every frame, though the frames wont be consistent (the .ms rate). FixedDeltaTime is the same thing cept the frames are consistent. Useful for physics related stuff to prevent stuttering or anything that requires smooth movement.
    }
}
