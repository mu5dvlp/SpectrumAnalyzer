using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
#if UNITY_EDITOR
using UnityEditor.Experimental.GraphView;
#endif

namespace MU5Editor.NodeEditor
{
#if UNITY_EDITOR
    public class MU5Node : Node
    {
        public string uid = string.Empty;
        public Dictionary<string, Port> port_dict;

        public Label uidLabel = new Label();

        //<Methods>ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
        public void Init_UID()
        {
            if (uid != string.Empty) return;

            uid = MU5Utility.GenerateUID();
            viewDataKey = uid;
        }

        public void LoadData(NodeData nodeData)
        {
            uid = nodeData.uid;
            SetPosition(nodeData.localBound);
        }
    }
#endif
}