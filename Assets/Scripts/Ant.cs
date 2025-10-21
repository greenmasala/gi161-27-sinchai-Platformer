using UnityEngine;

public class Ant : Enemy
{
    [SerializeField] Vector2 velocity; //show private variable in unity instead of having to make it public
    public Transform[] MovePoints;
    
    void Start()
    {
        base.Init(30);
    }

    void Update()
    {

    }

    public override void Behavior()
    {
        throw new System.NotImplementedException();
    }
}
