using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private List<string> sceneNames = new List<string>();
    [SerializeField] private InputActionReference switchSceneAction;
    //[SerializeField] private FadeSphereToBlack fadeSphere;

    void OnEnable()
    {
        switchSceneAction.action.Enable(); // Should already be enabled, doing just in case
        switchSceneAction.action.performed += SwitchToNextScene;
        // Should also clean these up, also feed it through properly but it's hacky, sorry in advance
    }

    private void OnDisable()
    {
        switchSceneAction.action.Disable();
        switchSceneAction.action.performed -= SwitchToNextScene;
    }

    [ContextMenu("Switch Scene")]
    private void Wrapper()
    {
        SwitchToNextScene(new InputAction.CallbackContext());
    }

    private void SwitchToNextScene(InputAction.CallbackContext callbackContext)
    {
        var sceneToLoad = string.Empty;
        int index = 0;
        foreach (var sceneName in sceneNames)
        {
            if (SceneManager.GetActiveScene().name == sceneName)
            {
                index++;
                if (index >= sceneNames.Count)
                {
                    index = 0;
                }

                sceneToLoad = sceneNames[index];
                break;
            }

            index++;
        }

        StartCoroutine(FadeSphereThenLoad(sceneToLoad));
    }

    private IEnumerator FadeSphereThenLoad(string sceneToLoadName)
    {
        // // TODO - Get this working with the new Fader
        // if (fadeSphere != null)
        // {
        //     fadeSphere.FadeToBlack();
        //     yield return new WaitForSeconds(2f);
        // }

        yield return null;
        SceneManager.LoadScene(sceneToLoadName);
    }
}