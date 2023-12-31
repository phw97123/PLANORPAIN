using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TreadmilMiniGameUI : MonoBehaviour
{
    public IntVariable startAmount;

    [SerializeField] private GameObject _miniGameUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _npc;
    [SerializeField] private GameObject _gymObject;
    [SerializeField] private GameObject _treadmilCamera;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Animator _npcAnimator;
    [SerializeField] private Image _dropBarImage;
    [SerializeField] private Image _hitPointImage;
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _expressionText;
    [SerializeField] private TMP_Text _StartText;
    [SerializeField] private TMP_Text _SpaceText;
    [SerializeField] private TMP_Text _ScheduleText;

    private Vector3 _originPlayerPosition;
    private Quaternion _originPlayerQuaternion;
    private Vector3 _originNPCPosition;
    private Vector3 _originDropBarPos;
    private int _timeCount = 60;
    private int _score = 0;
    private int _maxScore = 1000;
    private float _startDelayTime = 2f;
    private float _failDelayTime = 2f;
    private float _dropValue = 0.003f;
    private float _hitPointImagePosY;
    private float _blendValue = 0f;
    private bool _isHit = true;
    private Color _originSpaceTextColor;

    private Color32 _red = new Color32(245, 80, 80, 255);
    private Color32 _green = new Color32(182, 217, 136, 255);
    private Color32 _blue = new Color32(92, 210, 230, 255);

    private void Start()
    {
        _hitPointImagePosY = _hitPointImage.transform.position.y;
        _originDropBarPos = _dropBarImage.transform.position;
        _timeText.text = $"{_timeCount} s";
        _scoreText.text = $"{_score} / {_maxScore}";
        _originSpaceTextColor = _SpaceText.color;
    }

    public void StartMiniGame()
    {
        _timeCount = 60;
        _score = 0;
        _blendValue = 0f;

        SoundManager.Instance.Stop();

        _player.GetComponent<PlayerInput>().enabled = false;
        _gymObject.GetComponent<Collider>().enabled = false;

        _treadmilCamera.SetActive(true);
        _miniGameUI.SetActive(true);

        _npcAnimator.SetBool("Run", true);
        _originNPCPosition = _npc.transform.position;
        _npc.transform.position = new Vector3(_gymObject.transform.position.x - 2.8f, 0.2f, _gymObject.transform.position.z + 0.5f);

        _playerAnimator.runtimeAnimatorController = Resources.Load("AnimatiorControllers/PlayerTreadmilAnimatorController") as RuntimeAnimatorController;

        _originPlayerPosition = _player.transform.position;
        _originPlayerQuaternion = _player.transform.rotation;
        _player.transform.rotation = Quaternion.Euler(Vector3.zero);
        _player.transform.position = new Vector3(_gymObject.transform.position.x - 0.5f, 0.3f, _gymObject.transform.position.z + 0.5f);
        StartCoroutine(TimeCountDownCO());
        StartCoroutine(DropBarImageChangeCO());
    }

    public void EndMiniGame()
    {
        if (_score >= _maxScore)
            startAmount.value += 1;

        _ScheduleText.color = Color.gray;
        _ScheduleText.fontStyle = FontStyles.Strikethrough;

        _npcAnimator.ResetTrigger("LookOver");
        _npcAnimator.SetBool("Run", false);
        _npc.transform.position = _originNPCPosition;

        _playerAnimator.runtimeAnimatorController = Resources.Load("AnimatiorControllers/PlayerAnimatorController") as RuntimeAnimatorController;

        _player.transform.position = _originPlayerPosition;
        _player.transform.rotation = _originPlayerQuaternion;

        StopAllCoroutines();

        _miniGameUI.SetActive(false);
        _treadmilCamera.SetActive(false);

        _player.GetComponent<PlayerInput>().enabled = true;
        _gymObject.GetComponent<Collider>().enabled = true;

        SoundManager.Instance.Play("OutdoorGame/DrumsAndBass", AudioType.BGM);
    }

    public void OnHitBar(InputAction.CallbackContext context)
    {
        if (!_isHit)
            if (context.phase == InputActionPhase.Started)
            {
                if (_hitPointImagePosY - 0.006f <= _dropBarImage.transform.position.y && _dropBarImage.transform.position.y <= _hitPointImagePosY + 0.006f)
                {
                    StartCoroutine(SuccessHitCO());
                }
                else
                {
                    StartCoroutine(FailHitCO());
                }

            }
    }

    IEnumerator SuccessHitCO()
    {
        _isHit = true;
        _SpaceText.color = _green; // green

        _playerAnimator.ResetTrigger("Fail");
        _playerAnimator.SetTrigger("Success");

        SoundManager.Instance.Play("OutdoorGame/Treadmil_Step");

        _blendValue += 0.1f;
        _playerAnimator.SetFloat("Blend", _blendValue);

        if (_hitPointImagePosY - 0.003f < _dropBarImage.transform.position.y && _dropBarImage.transform.position.y < _hitPointImagePosY + 0.003f)
        {
            StartCoroutine(ToastExpressionTextCO("Perfect!", _blue));  // blue
            _score += 100;
        }
        else
        {
            StartCoroutine(ToastExpressionTextCO("Good!", _green));    // green
            _score += 50;
        }

        if (_score >= _maxScore)
        {
            _scoreText.color = _green; // green
        }

        _scoreText.text = $"{_score} / {_maxScore}";

        yield return new WaitForSecondsRealtime(0.5f);

        _dropBarImage.transform.position = _originDropBarPos;
        _SpaceText.color = _originSpaceTextColor;

        _isHit = false;
    }

    IEnumerator FailHitCO()
    {
        _isHit = true;
        _SpaceText.color = _red;   // red

        _playerAnimator.SetTrigger("Fail");
        _npcAnimator.ResetTrigger("LookOver");
        _npcAnimator.SetTrigger("LookOver");

        SoundManager.Instance.Stop();
        SoundManager.Instance.Play("OutdoorGame/Fail");

        StartCoroutine(ToastExpressionTextCO("Bad!", _red));   // red

        yield return new WaitForSecondsRealtime(_failDelayTime);

        _dropBarImage.transform.position = _originDropBarPos;
        _SpaceText.color = _originSpaceTextColor;

        _isHit = false;
    }

    IEnumerator ToastExpressionTextCO(string expression, Color color)
    {
        _expressionText.gameObject.SetActive(true);

        _expressionText.text = expression;
        _expressionText.color = color;

        yield return new WaitForSecondsRealtime(1f);

        _expressionText.gameObject.SetActive(false);
    }

    IEnumerator TimeCountDownCO()
    {
        yield return new WaitForSecondsRealtime(_startDelayTime);

        _timeText.gameObject.SetActive(false);
        _StartText.gameObject.SetActive(true);

        yield return new WaitForSecondsRealtime(1f);

        _timeText.gameObject.SetActive(true);
        _StartText.gameObject.SetActive(false);
        _isHit = false;

        while (_timeCount >= 0)
        {
            yield return new WaitForSecondsRealtime(1f);
            _timeCount += -1;
            _timeText.text = $"{_timeCount} s";

            if (_timeCount <= 0)
            {
                _isHit = true;
                StopCoroutine(DropBarImageChangeCO());
                yield return new WaitForSecondsRealtime(2f);
                _timeText.text = "END";
                yield return new WaitForSecondsRealtime(2f);
                EndMiniGame();
            }
        }
    }

    IEnumerator DropBarImageChangeCO()
    {
        Vector3 dropValue = new Vector3(0, _dropValue, 0);

        yield return new WaitForSecondsRealtime(_startDelayTime);

        while (true)
        {
            if (!_isHit)
            {
                _dropBarImage.transform.position -= dropValue;
                yield return null;

                if (_dropBarImage.transform.position.y < _hitPointImagePosY - 0.02f)
                    StartCoroutine(FailHitCO());
            }
            yield return null;
        }
    }
}
