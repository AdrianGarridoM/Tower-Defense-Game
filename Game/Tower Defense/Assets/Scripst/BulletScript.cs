using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Transform Target;
    public void Chase(Transform target)
    {
        Target = target;
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        if(Target == null)
        {
            Destroy(gameObject);
        }
    }
}
