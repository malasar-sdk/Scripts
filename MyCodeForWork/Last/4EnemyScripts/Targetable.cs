using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targetable : MonoBehaviour
{
    [SerializeField] private enum EnemyType { Minion }
    [SerializeField] private EnemyType enemyType;
}
