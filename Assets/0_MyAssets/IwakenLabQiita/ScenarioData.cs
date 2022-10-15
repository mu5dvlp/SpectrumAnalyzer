using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MU5Editor.NodeEditor
{
    [CreateAssetMenu(menuName = "MU5/ScenarioData")]
    public class ScenarioData : ScriptableObject
    {
        public List<NodeData> nodeData_list;
        public List<EdgeData> edgeData_list;
    }

    //ーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーーー
    [Serializable]
    public class NodeData
    {
        public string uid;
        public string nodeType_str;
        public Type nodeType { get { return Type.GetType(nodeType_str); } }
        public Rect localBound;
    }

    //ーーーーーーーーーーーーーーーーーーーーー
    [Serializable]
    public class EdgeData
    {
        public string uid_outputNode;
        public string uid_outputPort;
        public string uid_inputNode;
        public string uid_inputPort;
    }
}