using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrow : Interaction
{

    public GameObject webstring;
    public GameObject spider;

    // Use this for initialization
    void Start()
    {
    }

    IEnumerator KnifeThrowCo(InteractiveThing thing)
    {
        LeanTween.rotate(this.gameObject, new Vector3(90, 0, -30), 2f).setEase(LeanTweenType.easeOutSine);
        yield return new WaitForSeconds(3f);
        LeanTween.move(this.gameObject, thing.transform.position, 1.5f).setEase(LeanTweenType.easeOutSine);
        yield return new WaitForSeconds(1.2f);
        webstring.SetActive(false);
        spider.GetComponent<ObtainableItem>().isAbleToInteract = true;
        spider.GetComponent<Rigidbody>().isKinematic = false;
        spider.GetComponent<Rigidbody>().useGravity = true;
        LeanTween.rotate(spider.gameObject, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeOutSine);
        yield return null;
    }

    public override bool IsAbleToInteractWith(InteractiveThing thing)
    {
        return thing.name == ("Target");
    }

    public override void InteractWith(InteractiveThing thing)
    {
        StartCoroutine(KnifeThrowCo(thing));
    }
}
