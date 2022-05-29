using UnityEngine;
using UnityEngine.AI;

public class BotEnemyMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _navAgent;
    private Transform _playerPosition;
    void Start()
    {
        _playerPosition = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        _navAgent.SetDestination(_playerPosition.position);
    }

}
