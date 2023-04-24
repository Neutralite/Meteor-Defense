using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject targetCity;
    public int size;
 
    private void OnEnable()
    {
        size = Random.Range(1, 4);
        switch (size)
        {
            case 1:
                transform.localScale = Vector3.one*0.5f;
                break;            
            case 2:
                transform.localScale = Vector3.one;
                break;            
            case 3:
                transform.localScale = Vector3.one*1.5f;
                break;
        }
    }


}
