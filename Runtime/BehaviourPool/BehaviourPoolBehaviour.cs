using SorceressSpell.LibrarIoh.Collections;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public abstract class BehaviourPoolBehaviour<TBehaviour> : IPoolObject
        where TBehaviour : Behaviour
    {
        #region Properties

        public TBehaviour Behaviour { private set; get; }

        #endregion Properties

        #region Constructors

        public BehaviourPoolBehaviour()
        {
            Behaviour = null;
        }

        public BehaviourPoolBehaviour(GameObject gameObject)
        {
            AttachTo(gameObject);
        }

        #endregion Constructors

        #region Methods

        public void Activate()
        {
            Behaviour.enabled = true;

            BehaviourPoolBehaviour_OnActivate();
        }

        public void AttachTo(GameObject gameObject)
        {
            if (gameObject != null)
            {
                Behaviour = gameObject.AddComponent<TBehaviour>();
            }
        }

        public void Deactivate()
        {
            BehaviourPoolBehaviour_OnDeactivate();

            Behaviour.enabled = false;
        }

        public void Destroy()
        {
            BehaviourPoolBehaviour_OnDestroy();

            UnityEngine.Behaviour.Destroy(Behaviour);
        }

        public void Initialize(string name)
        {
            BehaviourPoolBehaviour_OnInitialize();
        }

        public bool IsActive()
        {
            return Behaviour.enabled;
        }

        public void Update(float deltaTime)
        {
            BehaviourPoolBehaviour_OnUpdate(deltaTime);
        }

        protected virtual void BehaviourPoolBehaviour_OnActivate()
        {
        }

        protected virtual void BehaviourPoolBehaviour_OnDeactivate()
        {
        }

        protected virtual void BehaviourPoolBehaviour_OnDestroy()
        {
        }

        protected virtual void BehaviourPoolBehaviour_OnInitialize()
        {
        }

        protected virtual void BehaviourPoolBehaviour_OnUpdate(float deltaTime)
        {
        }

        #endregion Methods
    }
}
