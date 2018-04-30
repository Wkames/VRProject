using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnInteract : Interaction
{

    public GameObject target_animated;
    public GameObject target_start;
    public GameObject target_end;
    private bool played;
    private Vector3 targetend_pos;
    private Animation anim;

    void Start()
    {
        played = false;
        //targetend_pos = target_end.transform.position;
        //target_end.transform.position.Set(-500, -500, -500);
    }

    IEnumerator PlayAnimation()
    {
        if (target_animated == null)
        {
            target_animated = gameObject;
        }

        anim = target_animated.GetComponent<Animation>();
        anim.Play();
        target_start.SetActive(false);
        played = true;

        yield return new WaitForSeconds(25f);

        anim.Stop();

        target_end.SetActive(true);

        yield return null;
    }

    private void Update()
    {
        if (anim != null)
        {
            if (!anim.isPlaying && played)
            {
                //target_end.SetActive(true);
                //target_end.transform.position.Set(targetend_pos.x, targetend_pos.y, targetend_pos.z);
            }
        }
    }

    public override void Interact()
    {
        if (!played)
        {
            StartCoroutine(PlayAnimation());
        }
    }
}
