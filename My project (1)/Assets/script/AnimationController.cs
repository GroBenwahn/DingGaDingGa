using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject hitPrefab;
    public GameObject hitGoodPrefab;
    public GameObject missPrefab;

    public void OnHit()
    {       
        Score.Hit();        
        CreateAndPlayAnimation(hitPrefab);
        Debug.Log("OnHit called");
    }

    public void OnHitGood()
    {
        Debug.Log("OnHitGood called");
        CreateAndPlayAnimation(hitGoodPrefab);
        Score.HitGood();
    }

    public void OnMiss()
    {
        Debug.Log("OnMiss called");
        CreateAndPlayAnimation(missPrefab);
        Score.Miss();
    }

    private void CreateAndPlayAnimation(GameObject prefab)
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab is null");
            return;
        }

        GameObject animationObject = Instantiate(prefab, transform.position, Quaternion.identity);
        Debug.Log("Instantiated animation object: " + animationObject.name);

        Animator animator = animationObject.GetComponent<Animator>();
        if (animator != null)
        {
            Debug.Log("Animator component found on instantiated object");
            StartCoroutine(DestroyAfterAnimation(animator, animationObject));
        }
        else
        {
            Debug.LogWarning("Animator component missing in prefab: " + prefab.name);
            Destroy(animationObject);
        }
    }

    private IEnumerator DestroyAfterAnimation(Animator animator, GameObject animationObject)
    {
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }

        Debug.Log("Animation finished, destroying object: " + animationObject.name);
        Destroy(animationObject);
    }
}
