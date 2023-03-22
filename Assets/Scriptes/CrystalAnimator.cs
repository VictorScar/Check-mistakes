using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins;

public class CrystalAnimator : MonoBehaviour
{
    [SerializeField] Camera gameCamera;
    [SerializeField] GameObject crytalSpritePrefab;
    List<GameObject> crytalSprites = new List<GameObject>();
    [SerializeField] GameObject crytalIcon;

    //[SerializeField] float animationSpeed = 5;
    [SerializeField] float animationDuration = 0.5f;
    [SerializeField] int poolSize = 1;
    int spriteNumber = 0;

    private void Start()
    {
        CreateSpritesPool(poolSize);
    }

    void CreateSpritesPool(int poolSize)
    {
        for (int i = 0; i < poolSize; i++)
        {
            AddSpriteInPool();
        }
    }

    void AddSpriteInPool()
    {
        var spriteInstance = Instantiate(crytalSpritePrefab.gameObject, transform);
        crytalSprites.Add(spriteInstance);
        spriteInstance.SetActive(false);
    }

    public void CollectAnimation(Vector3 crystalPosition)
    {
        if (spriteNumber >= crytalSprites.Count)
        {
            AddSpriteInPool();
        }
        var currentSprite = crytalSprites[spriteNumber];

        currentSprite.transform.position = gameCamera.WorldToScreenPoint(crystalPosition);

        SetSpriteState(currentSprite, true);
        Sequence sequence = DOTween.Sequence();
        sequence.Append(currentSprite.transform.DOMove(crytalIcon.transform.position, animationDuration));
        sequence.Join(currentSprite.transform.DOScale(crytalIcon.transform.localScale, animationDuration));
        sequence.OnComplete(() => SetSpriteState(currentSprite, false));

        //StartCoroutine(CollectPointCoroutine(crytalSprites[spriteNumber]));
    }

    void SetSpriteState(GameObject currentSprite, bool enable)
    {
        currentSprite.SetActive(enable);
        if (enable)
        {
            spriteNumber++;
            return;
        }
        spriteNumber--;
    }

    //IEnumerator CollectPointCoroutine(GameObject sprite)
    //{
    //    spriteNumber++;
    //    while (sprite.transform.position != crytalIcon.transform.position)
    //    {
    //        sprite.transform.position = Vector3.MoveTowards(sprite.transform.position, crytalIcon.transform.position,
    //                                                                animationSpeed * Time.deltaTime);
    //        if (sprite.transform.localScale != crytalIcon.transform.localScale)
    //        {
    //            sprite.transform.localScale = Vector3.Lerp(sprite.transform.localScale, crytalIcon.transform.localScale,
    //                                                        0.4f * Time.deltaTime);
    //        }
    //        yield return null;
    //    }
    //    sprite.SetActive(false);
    //    spriteNumber--;
    //}
}
