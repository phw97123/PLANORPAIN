using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractGymPoint : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _interactionUI;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Vehicle"))
        {
            _interactionUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Vehicle"))
        {
            _interactionUI.SetActive(false);
        }
    }

    public void OnInteract()
    {
        StartCoroutine(LoadSceneCO());
    }

    IEnumerator LoadSceneCO()
    {
        yield return new WaitForSecondsRealtime(1f);
        //SceneManager.LoadScene("GymScene");
        Debug.Log("LoadScene : GymScene");
    }
}
