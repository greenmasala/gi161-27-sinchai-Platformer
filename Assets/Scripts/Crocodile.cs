using UnityEngine;

public class Crocodile : Enemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        base.Init(60);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void Behavior()
    {
        throw new System.NotImplementedException();
    }
}
