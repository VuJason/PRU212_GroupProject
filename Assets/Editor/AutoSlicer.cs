using UnityEditor;
using UnityEngine;

public class AutoSlicer : EditorWindow
{
    private Texture2D selectedTexture;
    private int tileWidth = 32;
    private int tileHeight = 32;

    [MenuItem("Tools/Auto Slice Texture (Custom Size)")]
    public static void ShowWindow()
    {
        GetWindow<AutoSlicer>("Auto Slicer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Auto Slice Settings", EditorStyles.boldLabel);

        selectedTexture = (Texture2D)EditorGUILayout.ObjectField("Texture", selectedTexture, typeof(Texture2D), false);
        tileWidth = EditorGUILayout.IntField("Tile Width", tileWidth);
        tileHeight = EditorGUILayout.IntField("Tile Height", tileHeight);

        if (GUILayout.Button("Auto Slice"))
        {
            if (selectedTexture == null)
            {
                EditorUtility.DisplayDialog("Error", "Please select a texture.", "OK");
                return;
            }

            string path = AssetDatabase.GetAssetPath(selectedTexture);
            TextureImporter importer = AssetImporter.GetAtPath(path) as TextureImporter;

            if (importer == null)
            {
                Debug.LogError("Failed to load TextureImporter.");
                return;
            }

            importer.textureType = TextureImporterType.Sprite;
            importer.spriteImportMode = SpriteImportMode.Multiple;

            int textureWidth = selectedTexture.width;
            int textureHeight = selectedTexture.height;

            int columns = textureWidth / tileWidth;
            int rows = textureHeight / tileHeight;

            SpriteMetaData[] metas = new SpriteMetaData[columns * rows];
            int index = 0;

            for (int y = rows - 1; y >= 0; y--)
            {
                for (int x = 0; x < columns; x++)
                {
                    SpriteMetaData meta = new SpriteMetaData();
                    meta.name = $"{selectedTexture.name}_{x}_{y}";
                    meta.rect = new Rect(x * tileWidth, y * tileHeight, tileWidth, tileHeight);
                    meta.pivot = new Vector2(0.5f, 0.5f);
                    meta.alignment = (int)SpriteAlignment.Center;
                    metas[index++] = meta;
                }
            }

            importer.spritesheet = metas;
            EditorUtility.SetDirty(importer);
            AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

            EditorUtility.DisplayDialog("Done", "Slicing complete!", "OK");
        }
    }
}
