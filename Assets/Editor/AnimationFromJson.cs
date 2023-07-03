using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using System.Linq;

[System.Serializable]
public class AnimationData
{
    public string name;
    public int startFrame;
    public int endFrame;
}

[System.Serializable]
public class AnimationList
{
    public List<AnimationData> animations;
}

public class AnimationFromJson : EditorWindow
{
    [SerializeField] List<Sprite> sprites = new List<Sprite>();
    [SerializeField] TextAsset jsonFile;
    string animationPath = "Assets/Resources/Animations";

    [MenuItem("Custom/Animation From JSON")]
    public static void ShowWindow()
    {
        GetWindow<AnimationFromJson>("Animation From JSON");
    }

    private Vector2 scrollPos = Vector2.zero;
    private void OnGUI()
    {
        GUILayout.Label("Animation Generator from JSON", EditorStyles.boldLabel);
        GUILayout.Space(5);


        Event evt = Event.current;

        Rect sprite_drop_area = GUILayoutUtility.GetRect(0.0f, 100.0f, GUILayout.ExpandWidth(true));
        GUI.Box(sprite_drop_area, "Drag & Drop Sprites Here");
        GUILayout.Space(5);
        Rect json_drop_area = GUILayoutUtility.GetRect(0.0f, 100.0f, GUILayout.ExpandWidth(true));
        GUI.Box(json_drop_area, "Drag & Drop JSON File Here");

        GUILayout.Space(5);

        switch (evt.type)
        {
            case EventType.DragUpdated:
            case EventType.DragPerform:
                if (sprite_drop_area.Contains(evt.mousePosition))
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (UnityEngine.Object dragged_object in DragAndDrop.objectReferences)
                        {
                            if (dragged_object is Texture2D)
                            {
                                string path = AssetDatabase.GetAssetPath(dragged_object);
                                 UnityEngine.Object[] assets = AssetDatabase.LoadAllAssetsAtPath(path);
                                foreach (var asset in assets)
                                {
                                    if (asset is Sprite sprite)
                                    {
                                        // You have individual sprite here
                                        Debug.Log(sprite.name); // This should print "gunner_0", "gunner_1", etc.
                                        sprites.Add(sprite);
                                    }
                                }
                            }
                        }
                    }
                }
                else if (json_drop_area.Contains(evt.mousePosition))
                {
                    DragAndDrop.visualMode = DragAndDropVisualMode.Copy;

                    if (evt.type == EventType.DragPerform)
                    {
                        DragAndDrop.AcceptDrag();

                        foreach (UnityEngine.Object dragged_object in DragAndDrop.objectReferences)
                        {
                            if (dragged_object is TextAsset)
                            {
                                jsonFile = dragged_object as TextAsset;
                            }
                        }
                    }
                }
            break;
        }

        // Show list of sprites with scroll view
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(200));
        foreach (var sprite in sprites)
        {
            GUILayout.Label(sprite.name);
        }
        EditorGUILayout.EndScrollView();

        if (jsonFile != null)
        {
            EditorGUILayout.LabelField("Selected JSON file: " + jsonFile.name);
        }
        // Allow input of animation path
        animationPath = EditorGUILayout.TextField("Path to Save Animations", animationPath);

        // Clear Button
        if (GUILayout.Button("Clear Sprites"))
        {
            sprites.Clear();
        }
        if (GUILayout.Button("Clear JSON"))
        {
            jsonFile = null;
        }
        // Button to generate animations
        if (GUILayout.Button("Generate Animations"))
        {
            GenerateAnimations();
        }
    }

    private void GenerateAnimations()
    {
        AnimationList animationList = JsonUtility.FromJson<AnimationList>(jsonFile.text);

        foreach (AnimationData animationData in animationList.animations)
        {
            List<Sprite> animationSprites = sprites.GetRange(animationData.startFrame - 1, animationData.endFrame - animationData.startFrame + 1);
            GenerateAnimation(animationSprites, animationData.name);
        }
    }

    private void GenerateAnimation(List<Sprite> sprites, string animationName)
    {
        // Create a new animation clip
        AnimationClip clip = new AnimationClip();
        clip.frameRate = 30f; // FPS

        EditorCurveBinding curveBinding = new EditorCurveBinding
        {
            type = typeof(SpriteRenderer),
            path = "",
            propertyName = "m_Sprite"
        };

        ObjectReferenceKeyframe[] keyFrames = new ObjectReferenceKeyframe[sprites.Count];

        for (int i = 0; i < (sprites.Count); i++)
        {
            // Sprite sprite = AssetDatabase.LoadAssetAtPath<Sprite>(spritePaths[i]);  // 경로에서 스프라이트를 로드
            // Debug.Log(spritePaths[i]);
            keyFrames[i] = new ObjectReferenceKeyframe
            {
                time = i / 30f,
                value = sprites[i]
            };
        }

        AnimationUtility.SetObjectReferenceCurve(clip, curveBinding, keyFrames);

        // If folder does not exist, create it
        if (!Directory.Exists(animationPath))
        {
            Directory.CreateDirectory(animationPath);
        }

        // Save the animation clip
        AssetDatabase.CreateAsset(clip, Path.Combine(animationPath, $"{animationName}.anim"));
        AssetDatabase.SaveAssets();
        Debug.Log("succcess to make animations");
    }
}
