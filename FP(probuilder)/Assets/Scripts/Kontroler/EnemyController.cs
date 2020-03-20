using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookradius = 2f;

    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        //Dodjeljivanja igraca varijabli target
        target = PlayerManager.instance.player.transform;

        agent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        //Udaljenost neprijatelja od igraca
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookradius)
        {
             agent.SetDestination(target.position);

            //Namjestanje neprijatelja da se okrece prema nama
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
            }
        }
        
    }


    //Rotacija prema meti
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;//Pozicija mete
        //Rotacija mete
        Quaternion lookrotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //Nasa rotacija pokazuje na metu
        transform.rotation = Quaternion.Slerp(transform.rotation, lookrotation, Time.deltaTime *5f);
    }

    //Crteanje polja u kojem neprijatelj vidi
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookradius);
    }
}
