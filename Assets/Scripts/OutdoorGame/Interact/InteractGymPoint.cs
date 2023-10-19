using System.Collections;
using TMPro;
using UnityEngine;

public class InteractGymPoint : MonoBehaviour, IInteractable
{
    public IntVariable starAmount;

    [SerializeField] private GameObject _interactionUI;
    [SerializeField] private TMP_Text _todoListText;

    private bool _isInteract = false;

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
        if (!_isInteract)
        {
            StartCoroutine(LoadSceneCO());
            _isInteract = true;
        }
    }

    IEnumerator LoadSceneCO()
    {
        starAmount.value += 1;
        _todoListText.fontStyle = FontStyles.Strikethrough;

        yield return new WaitForSecondsRealtime(1f);

        SceneManagerEx.Instance.LoadScene(Scenes.GymScene);
    }
}
