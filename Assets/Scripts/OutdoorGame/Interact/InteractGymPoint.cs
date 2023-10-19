using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractGymPoint : MonoBehaviour, IInteractable
{
    public IntVariable starAmount;

    [SerializeField] private GameObject _interactionUI;
    [SerializeField] private TMP_Text _todoListText;

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
        starAmount.value += 1;
        _todoListText.fontStyle = FontStyles.Strikethrough;

        yield return new WaitForSecondsRealtime(1f);

        SceneManagerEx.Instance.LoadScene(Scenes.GymScene);
    }
}
