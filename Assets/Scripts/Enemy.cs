//using UnityEngine;

//public class Enemy : MonoBehaviour
//{
//    public Rigidbody2D RB { get; private set; }

//    public EnemyConfig Config;

//    public Enemy_Senses Senses { get; private set; }

//    public StateMachine StateMachine { get; private set; }


//    private void Awake()
//    {
//        RB = GetComponent<Rigidbody2D>();
//        StateMachine = new StateMachine();
//        Senses = GetComponent<Enemy_Senses>();
//    }
//    public void Initialize(State startingState)
//    {
//        StateMachine.Initialize(new PatrolState(this));
//    }

//    public void Start()
//    {
//        StateMachine.Initialize(new PatrolState(this));
//    }

//    private void Update()
//    {
//        StateMachine.CurrentState?.Update();
//    }


//    private void FixedUpdate()
//    {
//        StateMachine.CurrentState?.FixedUpdate();
//    }
//}
