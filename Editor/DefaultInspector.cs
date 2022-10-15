using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [CanEditMultipleObjects]
    [CustomEditor( inspectedType: typeof( Object ), editorForChildClasses: true, isFallback = true )]
    internal sealed class DefaultInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.UpdateIfRequiredOrScript();

            var iterator = serializedObject.GetIterator();

            for ( var enterChildren = true; iterator.NextVisible( enterChildren ); enterChildren = false )
            {
                EditorGUILayout.PropertyField( iterator, true );
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}