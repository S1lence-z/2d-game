using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Extensions
{
    public static bool DirectionTest(this Transform transform, Transform other, Vector2 testDirection)
    {
        Vector2 direction = other.position - transform.position;
        return Vector2.Dot(direction.normalized, testDirection) > 0.25f;
    }

    public static IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public static IEnumerator LoadAnimationWithDelay(Animator animator, string animationName, float delay)
    {
        yield return new WaitForSeconds(delay);
        animator.Play(animationName);
    }

    public static IEnumerator LoadMethodWithDelay(System.Action method, float delay)
    {
        yield return new WaitForSeconds(delay);
        method.Invoke();
    }
}