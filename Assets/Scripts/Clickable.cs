using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{
    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private SmallCube _smallCubePrefab;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private Resources _resources;

    private int _coinsPerClick = 1;

    // Анимация колебания куба
    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

    private void CreateSmallCube()
    {
        SmallCube newSmallCube = Instantiate(_smallCubePrefab, _spawnPoint.transform.position, Quaternion.identity);
        newSmallCube.Init(_resources);
        newSmallCube.FlipCube();
    }

    // Метод вызывается из Interaction при клике на объект
    public void Hit()
    {
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, transform.position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick);
        CreateSmallCube();
        StartCoroutine(HitAnimation());
    }

    // Этот метод увеличивает количество монет, получаемой при клике
    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

}
