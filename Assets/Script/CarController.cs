using UnityEngine;

public class CarController : MonoBehaviour
{

    public int speed = 10;

    
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
    }
}
