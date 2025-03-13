using UnityEngine;
using DG.Tweening;

public class ResourceFuel : Resource
{
    


    public override void Collect()
    {
        Destroy();
    }

    private void Destroy()
    {
        DOTween.Sequence()
            .Append(gameObject.transform.DOScale(0, 0.5f))
            .OnComplete(() => 
            {
                gameObject.SetActive(false);
            });
    }
}

