﻿using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class ReviewController : MonoBehaviour
{
    public GameObject UiReview;

    public GameObject QuestionPanel;
    public GameObject DecisionPanel;

    public bool GaveReview;
    public bool RefusedReview;
    public bool NoLike;
    public int ShowReviewAtLevel;

    private int _currentCompletedLevelsNumber;
    [SerializeField]
    public int CurrentCompletedLevelsNumber {
        get { return _currentCompletedLevelsNumber; }
        set
        {
            _currentCompletedLevelsNumber = value;

            if (GaveReview)
                return;

            if (_currentCompletedLevelsNumber <= 7)
            {
                ShowReviewAtLevel = 7;
            }
        }
    }

    public static ReviewController Instance;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        Init();
    }

    void Init()
    {
        UiReview.SetActive(false);

        QuestionPanel.SetActive(true);
        DecisionPanel.SetActive(false);
    }

    public void TryStartView(bool force = false)
    {
        if (GaveReview == false && CurrentCompletedLevelsNumber == ShowReviewAtLevel)
        {
            NoLike = false;
            RefusedReview = false;
            
            UiReview.SetActive(true);
        }
    }

    // Button Events
    public void OnNuChiar()
    {
        NoLike = true;
        ShowReviewAtLevel += 30;
        GameManager.Instance.ForceSaveGame();

        Init();
    }

    public void OnDa()
    {
        QuestionPanel.SetActive(false);
        DecisionPanel.SetActive(true);
    }

    public void OnNuMultumesc()
    {
        RefusedReview = true;
        ShowReviewAtLevel += 14;
        Init();
        GameManager.Instance.ForceSaveGame();
    }

    public void OnNormal()
    {
        Application.OpenURL("market://details?id=com.psdartist.aicuvinte/");

        GaveReview = true;
        Init();
        GameManager.Instance.ForceSaveGame();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            TryStartView(true);
        }
    }
}
