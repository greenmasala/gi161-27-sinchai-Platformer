using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image HealthBar;
    public Character character;

    void Start()
    {
        character = GetComponent<Character>();
        //GameObject.Find("Canvas").transform.GetChild(1).GetComponent<Image>();
    }

    void Update()
    {
        HealthBar.fillAmount = character.Health / character.MaxHealth;
    }
}
