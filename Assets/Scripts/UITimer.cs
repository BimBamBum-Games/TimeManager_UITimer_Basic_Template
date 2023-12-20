using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(-94)]
public class UITimer : MonoBehaviour {

    [SerializeField] TextMeshProUGUI _timerTmp;
    [SerializeField] Button _timerStartBtn, _timerStopBtn;

    private void OnEnable() {
        //Awake oldugundan itibaren OnEnable birlikte calisir. OnDisable ise Destroy aninda cagrilir. Tersiyerdir.
        _timerStartBtn.onClick.AddListener(TimeManager.Instance.StartTimer);
        _timerStopBtn.onClick.AddListener(TimeManager.Instance.StopTimer);
        TimeManager.Instance.OnElapsedTimeChanged += UpdateTimer;
    }

    private void OnDisable() {
        //Mem serbest birak.
        _timerStartBtn.onClick.RemoveListener(TimeManager.Instance.StartTimer);
        _timerStopBtn.onClick.RemoveListener(TimeManager.Instance.StopTimer);
        TimeManager.Instance.OnElapsedTimeChanged -= UpdateTimer;
    }

    private void UpdateTimer(float elapsedTime) {
        //Callback olarak guncellenecek timer class bu metodu feedleyecek.
        _timerTmp.text = elapsedTime.ToString("F2");
    }
}