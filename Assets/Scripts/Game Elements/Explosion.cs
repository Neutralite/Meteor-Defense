using UnityEngine;

public class Explosion : MonoBehaviour
{
    public bool finished,eraseAffected;
    private void OnEnable()
    {
        finished = false;
    }

    void EraseAffected()
    {
        eraseAffected = true;
    }

    void Despawn()
    {
        finished = true;
        gameObject.SetActive(false);
        ObjectPoolManager.Instance.ReturnObject(gameObject);
        eraseAffected = false;
    }
}
