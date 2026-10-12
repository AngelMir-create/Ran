using UnityEngine;

public class CatAnimatorController : MonoBehaviour
{
    public Animator animatorCat;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            animatorCat.SetBool("Jump", true);
        }
    }
}
