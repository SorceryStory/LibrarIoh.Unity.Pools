using SorceressSpell.LibrarIoh.Collections;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class BehaviourPool<TBehaviour, TPoolBehaviour> : Pool<TPoolBehaviour>
        where TBehaviour : Behaviour
        where TPoolBehaviour : BehaviourPoolBehaviour<TBehaviour>, new()
    {
        #region Fields

        private readonly GameObject _poolGameObject;

        #endregion Fields

        #region Constructors

        public BehaviourPool(string poolName, Transform parentTransform, int preAllocate)
            : base()
        {
            _poolGameObject = new GameObject(poolName);
            _poolGameObject.transform.SetParent(parentTransform, true);

            Allocate(preAllocate);
        }

        public BehaviourPool(GameObject poolGameObject, int preAllocate)
            : base()
        {
            _poolGameObject = poolGameObject;

            Allocate(preAllocate);
        }

        #endregion Constructors

        #region Methods

        protected override TPoolBehaviour Pool_CreatePoolObject()
        {
            TPoolBehaviour poolBehaviour = new TPoolBehaviour();
            poolBehaviour.AttachTo(_poolGameObject);

            return poolBehaviour;
        }

        protected override void Pool_PostDestroyAll()
        {
            GameObject.Destroy(_poolGameObject);
        }

        #endregion Methods
    }
}
