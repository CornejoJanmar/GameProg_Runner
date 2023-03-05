using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObstacleMovement : MonoBehaviour
{

    [Header("Rotate Parameters")]

    [SerializeField] bool objectRotates;
    [SerializeField] Vector3 rotate;
    [SerializeField] Vector3 startPosR;
    [SerializeField] Vector3 endPosR;
    [SerializeField] float spinDuration;
    [SerializeField] int LoopAmount;
    [SerializeField] LoopType LoopType;
    [SerializeField] bool IsRepeatable;

    [Header("Move Parameters")]

    [SerializeField] bool objectMoves;
    [SerializeField] Vector3 startPosM;
    [SerializeField] Vector3 endPosM;
    [SerializeField] float moveDuration;
    [SerializeField] int moveLoopAmount;
    [SerializeField] LoopType moveLoopType;

    void Start()
    {

        //transform.DOLocalMove(endPos,moveDuration).SetLoops(moveLoopAmount, moveLoopType).SetEase(Ease.Linear);
        if (objectMoves == true)
        {
            startMovement();
        }

        if(objectRotates == true)
        {
            if (IsRepeatable == true)
            {
                startRotate();
            }
            else
            {
                transform.DORotate(rotate, spinDuration, RotateMode.LocalAxisAdd).SetLoops(LoopAmount, LoopType).SetEase(Ease.Linear);
            }
        }

    }

    void startRotate()
    {
        transform.DORotate(endPosR, spinDuration, RotateMode.LocalAxisAdd).OnComplete(() => restartRotate()).SetEase(Ease.Linear);
    }

    void restartRotate()
    {
        transform.DORotate(startPosR, spinDuration, RotateMode.LocalAxisAdd).OnComplete(() => startRotate()).SetEase(Ease.Linear);
    }

    void startMovement()
    {
        transform.DOLocalMove(endPosM, moveDuration).OnComplete(() => restartMovement()).SetEase(Ease.Linear);
    }

    void restartMovement()
    {
        transform.DOLocalMove(startPosM, moveDuration).OnComplete(() => startMovement()).SetEase(Ease.Linear);
    }
}
