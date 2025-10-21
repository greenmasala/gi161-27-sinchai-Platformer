using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity; //show private variable in unity instead of having to make it public
    public Transform[] MovePoints;
    
    void Start()
    {
        base.Init(30);
        DamageHit = 5;

        velocity = new Vector2(-1.0f, 0.0f); //speed of ant. -1 is going to the left
    }

    void Update()
    {
        //Debug.Log(Time.deltaTime); //deltatime here is dependent on framerate unlike fixed, making the frames inconsistent
    }

    void FixedUpdate()
    {
        Behavior();
        //Debug.Log(Time.fixedDeltaTime);
    }

    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); 
        
        //move from one position to another. (rb.position is position of ant) DeltaTime is basically making it move every frame, though the frames wont be consistent (the .ms rate). FixedDeltaTime is the same thing cept the frames are consistent. Useful for physics related stuff to prevent stuttering or anything that requires smooth movement.

        if (velocity.x < 0 && rb.position.x <= MovePoints[0].position.x) //less than 0 = -1 = going to the left
        {
            Flip();
        }

        if (velocity.x > 0 && rb.position.x >= MovePoints[1].position.x) //more than 0 = going to the right
        {
            Flip();
        }
    }

    public void Flip()
    {
        velocity.x *= -1; //change direction of movement

        //flip image
        Vector3 scale = transform.localScale; //getting direction of image
        scale.x *= -1;
        transform.localScale = scale;
    }
}
