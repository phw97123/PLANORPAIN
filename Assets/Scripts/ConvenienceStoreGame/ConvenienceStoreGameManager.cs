using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConvenienceStoreGameManager : MonoBehaviour
{
    [SerializeField] private GameObject riceBall;
    [SerializeField] private GameObject virtualMainCamera;
    [SerializeField] private GameObject CCTVCamera;

    public event Action ChangeScoreEvent;

    public GameObject Player;
    public bool isWithinNPCZone;

    public bool isEating;
    public float eatingRate = 5.0f;

    public int score { get; private set; } = 3;
    private int _progress = 0; //횟수 5번으로 늘리기
    private bool _isInCCTV => CCTVCamera.transform.rotation.eulerAngles.y < 130.146f;
    private Renderer _riceBallRenderer;
    private Material[] _riceBallMaterials;

    private UIManager _uiManager;

    private static ConvenienceStoreGameManager _instance;

    public static ConvenienceStoreGameManager Instance
    {
        get
        {
            if (_instance != null) { return _instance; }

            _instance = FindObjectOfType<ConvenienceStoreGameManager>();
            if (_instance != null) { return _instance; }

            _instance = new GameObject(nameof(ConvenienceStoreGameManager)).AddComponent<ConvenienceStoreGameManager>();
            return _instance;
        }
    }

    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        virtualMainCamera.transform.parent = Player.transform;

        _riceBallRenderer = riceBall.GetComponent<Renderer>();
        _riceBallRenderer.enabled = true;

        _riceBallMaterials = new Material[5];
        for (int i = 0; i < _riceBallMaterials.Length; i++)
        {
            _riceBallMaterials[i] = Resources.Load<Material>($"Materials/Base_Color{i + 2}");
        }

        _uiManager = UIManager.Instance;
    }

    private void Start()
    {
        ConvenienceNotifyUI notifyUI = _uiManager.GetUIComponent<ConvenienceNotifyUI>();
        notifyUI.ShowPopup();
        ConvenienceUI gameUI = _uiManager.GetUIComponent<ConvenienceUI>();
        gameUI.OpenUI();
    }

    private void Update()
    {
        CheckClickRiceBall();
    }

    private void CheckClickRiceBall()
    {
        if (Time.timeScale > 0 && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == riceBall.name)
                {
                    if (isEating)
                    {
                        UI_Popup popupUI = _uiManager.GetUIComponent<UI_Popup>();
                        popupUI.ShowPopup("아직 씹고 있습니다");
                        return;
                    }
                    isEating = true;
                    Invoke("OnCanEating", eatingRate);

                    ChangeRiceBallModel();

                    if (isWithinNPCZone)
                    {
                        UI_Popup popupUI = _uiManager.GetUIComponent<UI_Popup>();
                        popupUI.ShowPopup("손님이 부스럭대는 소리를\r\n들었습니다");
                        ChangeScore(-1);
                    }

                    if (_isInCCTV || _progress == 5)
                    {
                        UI_GameEndPopup _endingUI = _uiManager.GetUIComponent<UI_GameEndPopup>();
                        _endingUI.ShowPopup("삼각김밥을 다 먹었습니다", 50);
                        if (_isInCCTV)
                        {
                            _endingUI.ShowPopup("CCTV를 보고 있던 점장님께 딱 들켰습니다", 50);
                            ChangeScore(-score);
                        }

                        Time.timeScale = 0;

                        _endingUI.SetScore(score);
                    }
                }
            }
        }
    }

    private void ChangeScore(int change)
    {
        score += change;
        if (score < 0) score = 0;
        ChangeScoreEvent?.Invoke();
    }

    private void OnCanEating()
    {
        isEating = false;
    }

    private void ChangeRiceBallModel()
    {
        _riceBallRenderer.sharedMaterial = _riceBallMaterials[_progress];

        _progress++;
    }
}
