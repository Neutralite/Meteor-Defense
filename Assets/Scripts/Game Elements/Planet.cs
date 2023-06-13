using UnityEngine;
using UnityEngine.UI;

public class Planet : MonoBehaviour
{
    public static Planet Instance { get; private set; }
    [SerializeField]
    Text healthText;
    int health = 100;
    public int Health
    {
        get => health;
        set
        {
            health = value;
            health = health < 0 ? 0 : health;
            healthText.text = $"Planet Health: {health}";
        }
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Meteor"))
        {
            Health -= 10;
        }
    }
}
