using UnityEngine;

namespace RepeatUtil.DesignPattern.ObjectPooling
{
    public class TransformListObjectPooling : ListObjectPooling<Transform>
    {
        public override Transform GetPrefabByInstanceFromPrefabList<I>(I instance)
        {
            foreach (Transform prefab in prefabList)
            {
                if (prefab.name == instance.name)
                    return prefab;
            }
            return null;
        }
    }
}