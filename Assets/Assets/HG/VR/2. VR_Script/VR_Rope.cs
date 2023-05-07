using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Rope : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float lineWidth = 0.1f;
    public Color lineColor = Color.white;
    private LineRenderer lineRenderer;
    private Coroutine drawCoroutine;

    private void Awake()
    {
        endPoint = GameObject.Find("R_Hands").transform;
    }

    private void Start()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.numCornerVertices = 10;
        lineRenderer.numCapVertices = 10;

        drawCoroutine = StartCoroutine(DrawLineRenderer()); // 코루틴 실행
    }

    private void OnDestroy()
    {
        if (drawCoroutine != null)
        {
            StopCoroutine(drawCoroutine); // 코루틴 종료
        }
    }

    IEnumerator DrawLineRenderer()
    {
        lineRenderer.enabled = true; // 라인 렌더러 활성화
        lineRenderer.positionCount = 100; // 라인 렌더러 위치 개수 설정

        while (true)
        {
            // 라인 렌더러 위치 업데이트
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, endPoint.position);

            yield return new WaitForSeconds(0.1f); // 0.1초 대기
        }
    }

    public void ClearLineRenderer()
    {
        if (drawCoroutine != null)
        {
            StopCoroutine(drawCoroutine); // 코루틴 종료
        }

        lineRenderer.positionCount = 0; // 라인 렌더러 초기화
        lineRenderer.enabled = false; // 라인 렌더러 비활성화
    }
}

