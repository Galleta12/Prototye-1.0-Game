using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using BT;
public class BehaviourTreesEditor : EditorWindow
{
    //[SerializeField]
    //private VisualTreeAsset m_VisualTreeAsset = default;


    BehaviourTreeView treeView;
    InspectorView inspectorView;
    //[MenuItem("Window/UI Toolkit/BehaviourTreesEditor")]
    [MenuItem("Behaviour Trees/Editor ...")]
    public static void OpenWindow()
    {
        BehaviourTreesEditor wnd = GetWindow<BehaviourTreesEditor>();
        wnd.titleContent = new GUIContent("BehaviourTreesEditor");
    }

    public void CreateGUI()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        // VisualElement label = new Label("Hello World! From C#");
        // root.Add(label);

        // Instantiate UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/BehaviourTreesEditor.uxml");
       // VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        //root.Add(labelFromUXML);
        visualTree.CloneTree(root);
        
        
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/BehaviourTreesEditor.uss");
        root.styleSheets.Add(styleSheet);


        treeView = root.Q<BehaviourTreeView>();
        inspectorView = root.Q<InspectorView>();

        treeView.OnNodeSelected = OnNodeSelectionChanged;
        OnSelectionChange();

    }


    private void OnSelectionChange() {
        BehaviourTree tree = Selection.activeObject as BehaviourTree;
        
        //if a new bt is create. and if the asset is not ready. with the root node it can throw an error about a object that 
        //is not serialize
        //hence we need to hacek with the asset
        if(tree && AssetDatabase.CanOpenAssetInEditor(tree.GetInstanceID())){
            treeView.PopulateView(tree);
        }

    }


    void OnNodeSelectionChanged(NodeView nodeView){
        inspectorView.UpdateSelection(nodeView);
    }


}
