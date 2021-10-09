using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
public class ArakhshScript : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float rotLerp = 1f;
    [SerializeField] private AbilityQ ability1;
    [SerializeField] private AbilityW ability2;

    [SerializeField] private Animator anim;
    [SerializeField] private AnimationClip q;
    [SerializeField] private AnimationClip w;

    private bool isCasting;
    private Vector3 target;




    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !isCasting)
        {
            target = Manager.instance.mousePos;
            agent.SetDestination(target);
            anim.SetBool("Walk", true);
            StartCoroutine(FixRot());
        }

        if (Vector3.Distance(transform.position, target) <= .2f)
            anim.SetBool("Walk", false);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(SpawnQ());
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(SpawnW());
        }

    }

    private IEnumerator SpawnQ()
    {
        isCasting=true;
        anim.SetBool("Walk", false);
        anim.SetTrigger("Q");
        SetRot();

        agent.SetDestination(transform.position);
        yield return new WaitForSeconds(q.length / 2);
        ability1.Spawn();
        isCasting=false;
    }

    private IEnumerator SpawnW()
    {
        isCasting=true;
        anim.SetBool("Walk", false);
        anim.SetTrigger("W");
        SetRot();
        agent.SetDestination(transform.position);
        yield return new WaitForSeconds(w.length / 2);
        ability2.Spawn(Manager.instance.mousePos);
        isCasting=false;
    }

    private async Task WaitForAnim(float time)
    {
        int delay = (int)(time * 1000);
        await Task.Delay(delay);
    }

    private void SetRot()
    {
        Vector3 pos = Manager.instance.mousePos;
        pos.y = transform.position.y;

        var rot = Quaternion.LookRotation(pos - transform.position);
        transform.rotation = rot;
    }

    IEnumerator FixRot()
    {
        Vector3 pos = Manager.instance.mousePos;
        pos.y = transform.position.y;
        var rot = Quaternion.LookRotation(pos - transform.position);

        while (transform.rotation != rot)
        {
            var lerp = Quaternion.RotateTowards(transform.rotation, rot, rotLerp * Time.deltaTime);
            transform.rotation = lerp;
            yield return null;
        }

    }

}
