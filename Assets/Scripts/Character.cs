using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]
public abstract class Character : MonoBehaviour
{
    [Header("UI")]
    [SerializeField]
    private Sprite frame;
    [Header("Character Info")]
    [SerializeField]
    private bool isAlive;
    [SerializeField]
    private string charName;
    [SerializeField]
    private float visionRadius;
    [SerializeField]
    private float attackRadius;
    [SerializeField]
    private float spellRadius;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int health;
    [SerializeField]
    private int atk;
    [SerializeField]
    private int def;
    [SerializeField]
    private int stm;
    [SerializeField]
    private int luck;
    [SerializeField]
    private int agi;
    [SerializeField]
    private int level;
    [SerializeField]
    private int gender;
    private Transform target;
    private bool isAttacking;
    private Coroutine attackRoutine;

    public float Speed { get => speed; set => speed = value; }
    public string CharName { get => charName; set => charName = value; }
    public Sprite Frame { get => frame; set => frame = value; }
    public int Health { get => health; set => health = value; }
    public int Atk { get => atk; set => atk = value; }
    public int Def { get => def; set => def = value; }
    public int Stm { get => stm; set => stm = value; }
    public int Luck { get => luck; set => luck = value; }
    public int Agi { get => agi; set => agi = value; }
    public int Level { get => level; set => level = value; }
    public int Gender { get => gender; set => gender = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public Coroutine AttackRoutine { get => attackRoutine; set => attackRoutine = value; }
    public float VisionRadius { get => visionRadius; set => visionRadius = value; }
    public float AttackRadius { get => attackRadius; set => attackRadius = value; }
    public float SpellRadius { get => spellRadius; set => spellRadius = value; }
    public Transform Target { get => target; set => target = value; }
    public bool IsAlive
    {
        get
        {
            isAlive = true;
            return true;
        }
    }

    public void HealCharacter(int health){}

    public virtual void TakeDamage(float damage)
    {
        if (IsAlive){}
    }
    // Start is called before the first frame update
    private void Start(){}

    // Update is called once per frame
    private void Update(){}
}
