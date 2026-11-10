using UnityEngine;

public class StartButton : MonoBehaviour
{ 
    public Animator animator;

    public GameObject[] objectsToHide;

    public void PlayAnimation()
    {
        Debug.Log("Raising the curtains!");

        animator.SetTrigger("CurtainUp");

        foreach (GameObject obj in objectsToHide)
        {
            obj.SetActive(false);
        }
    }
}
