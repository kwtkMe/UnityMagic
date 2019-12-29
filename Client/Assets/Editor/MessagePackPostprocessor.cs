using System;
using System.Diagnostics;
using System.Linq;
using UnityEditor;

public class MessagePackPostprocessor : AssetPostprocessor
{
    // 監視するディレクトリ
    private const string TargetDirectory = "Assets/Scripts/SharedClientWithServer";
    // 自動ビルド設定のMenuPath
    private const string AutoBuildMenuPath = "Tools/MessagePack/Auto Build";

    /// <summary>
    /// 自動ビルドするかどうかを切り替える
    /// </summary>
    [MenuItem("Tools/MessagePack/Auto Build")]
    private static void ToggleAutoBuild()
    {
        Menu.SetChecked(AutoBuildMenuPath, !Menu.GetChecked(AutoBuildMenuPath));
    }

    /// <summary>
    /// アセットインポート時の処理
    /// </summary>
    private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        // 自動ビルドがOFFなら終了
        if (!Menu.GetChecked(AutoBuildMenuPath)) return;

        // TargetDirectory のファイルが更新されたか確認
        var files = new[] { importedAssets, deletedAssets, movedAssets, movedFromAssetPaths }.SelectMany(_ => _);
        if (files.Any(x => x.StartsWith($"{TargetDirectory}"))) Generate();
    }
    /// <summary>
    /// 実処理
    /// </summary>
    [MenuItem("Tools/MessagePack/Build Resolvers")]
    private static void Generate()
    {
        // dotnet コマンドのパスを通す
        Environment.SetEnvironmentVariable("PATH", "/usr/local/share/dotnet");

        // MagicOnionCodeGenerator
        DoProcess(
            command: "../../GeneratorTools/MagicOnion.UniversalCodeGenerator/moc/osx-x64/moc",
            arguments: "-i ../Server/Server/Server.csproj -o Assets/Generated/MagicOnionResolver.cs"
        );

        // MessagePackCompiler
        DoProcess(
            command: "../../GeneratorTools/MessagePackUniversalCodeGenerator/osx-x64/mpc",
            arguments: "-i Assets -o Assets/GeneratedScripts/GeneratedResolver.cs"
        );
    }

    /// <summary>
    /// 外部プロセスを起動して、標準出力・標準エラー出力をログに表示する
    /// </summary>
    /// <param name="command">コマンド</param>
    /// <param name="arguments">引数</param>
    private static void DoProcess(string command, string arguments)
    {
        UnityEngine.Debug.Log($"コマンドを実行します: {command} {arguments}");
        var process = Process.Start(new ProcessStartInfo
        {
            FileName = command,
            Arguments = arguments,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        });
        UnityEngine.Debug.Log(process.StandardOutput.ReadToEnd());
        var error = process.StandardError.ReadToEnd();
        if (!string.IsNullOrEmpty(error)) UnityEngine.Debug.LogError(error);
    }
}