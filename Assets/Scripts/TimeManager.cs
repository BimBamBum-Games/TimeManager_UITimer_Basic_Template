using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Execution order onemli cunku singleton oldugundan diger komponentlere gore once olusmasi gerekir. Awake olmasi ise her diger executiondan da onceliklidir.
[DefaultExecutionOrder(-95)]
public class TimeManager : MonoBehaviour {

    [SerializeField]
    [Range(0f, 100f)]
    float _spanTime;

    private float elapsedTime = 0;
    [SerializeField] bool _isTimerLocked = true;

    // Action kullanarak etkileþimi saðlamak için bir Action tanýmla
    public Action<float> OnElapsedTimeChanged;
    public Action<float> OnClickedButtonTimer;

    //Singleton ornegi olacaktir.
    public static TimeManager Instance;

    private void Awake() {

        _isTimerLocked = true;

        if (Instance == null) {
            Instance = this;
        }
        else {
            Destroy(gameObject);
        }

    }

    private void Update() {

        if (_isTimerLocked) {
            return;
        }

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= _spanTime) {
            _isTimerLocked = true;
            return;
        }

        elapsedTime += Time.deltaTime;
        OnElapsedTimeChanged?.Invoke(elapsedTime);

    }

    public void StartTimer() {
        //Timer Starter Buttonu Cagiracaktir.
        _isTimerLocked = false;
        elapsedTime = 0;
    }

    public void StopTimer() {
        //Toggle olarak timeri durdur veya ac.
        _isTimerLocked = !_isTimerLocked;
    }
}