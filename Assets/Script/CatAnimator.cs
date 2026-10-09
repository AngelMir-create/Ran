using UnityEngine;

public class CatAnimator : MonoBehaviour
{
    public Animator animationCat;


    void Start()
    {
        animationCat.SetBool("runStart", true);
        Debug.Log("побежали");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationCat.SetTrigger("Jump");
            
        }
    }
}

