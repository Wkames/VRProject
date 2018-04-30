using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSummoner : Interaction {

    public GameObject ring1;
    public GameObject ring2;
    public GameObject ring3;
    public GameObject heart;
    public GameObject darkhole;
    private static int skullCount;
    private static Vector3 darkhole_scale;
    private static Vector3 heart_pos;

    // Use this for initialization
    void Start () {
        skullCount = 0;
        darkhole_scale = darkhole.transform.localScale;
        heart_pos = heart.transform.position;
        LeanTween.move(heart.gameObject, new Vector3(heart.transform.position.x, -1, heart.transform.position.z), 2f).setEase(LeanTweenType.easeOutSine);
        LeanTween.scale(darkhole.gameObject, new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeOutSine);
    }

    IEnumerator SummonHeartCo(InteractiveThing thing)
    {
        if (this.name == "skull1")
        {
            LeanTween.move(this.gameObject, new Vector3(ring1.transform.position.x, ring1.transform.position.y + 0.3f, ring1.transform.position.z), 2f).setEase(LeanTweenType.easeOutSine);
            LeanTween.rotate(this.gameObject, new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeOutSine);
            skullCount++;
        } else if (this.name == "skull2")
        {
            LeanTween.move(this.gameObject, new Vector3(ring2.transform.position.x, ring2.transform.position.y + 0.3f, ring2.transform.position.z), 2f).setEase(LeanTweenType.easeOutSine);
            LeanTween.rotate(this.gameObject, new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeOutSine);
            skullCount++;
        } else if (this.name == "skull3")
        {
            LeanTween.move(this.gameObject, new Vector3(ring3.transform.position.x, ring3.transform.position.y + 0.3f, ring3.transform.position.z), 2f).setEase(LeanTweenType.easeOutSine);
            LeanTween.rotate(this.gameObject, new Vector3(0, 0, 0), 2f).setEase(LeanTweenType.easeOutSine);
            skullCount++;
        }

        if (skullCount >= 3)
        {
            darkhole.SetActive(true);
            LeanTween.scale(darkhole.gameObject, darkhole_scale, 2f).setEase(LeanTweenType.easeOutSine);
            yield return new WaitForSeconds(1.5f);
            LeanTween.move(heart.gameObject, heart_pos, 2f).setEase(LeanTweenType.easeOutSine);
        }
        
        
        yield return new WaitForSeconds(0.2f);

        //gameObject.SetActive(false);
    }

    public override bool IsAbleToInteractWith (InteractiveThing thing) {
        return thing.name == ("heartRing");
	}

	public override void InteractWith (InteractiveThing thing) {
		StartCoroutine(SummonHeartCo(thing));
	}
}
