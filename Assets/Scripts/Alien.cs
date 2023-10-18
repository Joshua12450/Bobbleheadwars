using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
public class Alien : MonoBehaviour
{
    public UnityEvent OnDestroy;
    public Transform target;
    private NavMeshAgent agent;
    public float navigationUpdate;
    private float navigationTime = 0;
    // Start is called before the first frame update
    public void Die()
    {
        OnDestroy.Invoke();
        OnDestroy.RemoveAllListeners();
        Destroy(gameObject);
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        navigationTime += Time.deltaTime;
        if (navigationTime > navigationUpdate)
        {
            agent.destination = target.position;
            navigationTime = 0;
        }
        if (target != null)
        {
            agent.destination = target.position;

        }
    }
    void OnTriggerEnter(Collider Other)
    {
        Die();
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
    }
}