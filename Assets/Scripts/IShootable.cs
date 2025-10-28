using UnityEngine;

public interface IShootable //interface dont got codes or variable. all the variables are properties with get set. interface also dont got code, only methods.
{
    public GameObject Bullet {  get; set; }
    public Transform ShootPoint { get; set; }
    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }
    public void Shoot();
}
