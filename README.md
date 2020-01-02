# UnityMagic

## 参考URL
- [Unity+.NET Core+MagicOnionの環境構築ハンズオン -Qiita-](https://qiita.com/_y_minami/items/c7899fdf1db505c06ba2)
- [MagicOnion v2を使ってUnity IL2CPPでgRPC通信をする -Qiita-](https://qiita.com/yKimisaki/items/1d55b08f3e7bcae46585)
- [[ビルド前に実行するコマンド ライン] / [ビルド後に実行するコマンド ライン] ダイアログ ボックス](https://docs.microsoft.com/ja-jp/visualstudio/ide/reference/pre-build-event-post-build-event-command-line-dialog-box?view=vs-2019)
- [Github for Unity を導入してみる](https://tech.guitarrapc.com/entry/2017/07/14/031046)

## ディレクトリ構成など

### Scene
- ScriptController
    - スクリプトをアタッチする
    - ここでスクリプトを全部アタッチする

### Assets以下(その他ディレクトリ構成)
- Scripts/
    - Scratched/
        - 自前で記述したスクリプト
    - Scratched/AppUtil/
        - Sceneをまたいで利用するようなクラス
        - MonoBehaviourを継承しない
    - Scratched/ComponentScripts/
        - Scratched/AppUtilのスクリプトを利用する
        - シーン上のScriptControllerにアタッチする
            - (シーンのライフサイクルなどについて記述しないので忘れがち)
            - MonoBehaviourを継承する
    - Scratched/SceneScripts/
        - シーンのライフサイクル、UIの挙動に従うスクリプト
        - シーン上のScriptControllerにアタッチする


## GitHubのリポジトリにUnityプロジェクトが入りきらなかった

### 対策(なにをしたか)
なんかいろいろ試したけどこれが一番良さそうなのでやってある
- [Github for Unity を導入してみる](https://tech.guitarrapc.com/entry/2017/07/14/031046)

GitHubでUnityを管理しようとするとremote(GitHub)の容量が足りなくてつらいので、「Git LFS」というのをやっている

Gitででかい容量のリポジトリを扱うときに推奨される方式らしい

- [\\ [Git] \\.gitignoreの仕様詳解](https://qiita.com/anqooqie/items/110957797b3d5280c44f)

### その上でやったこと
Unityプロジェクトとサーバ用の.NETアプリと...をネストしてリポジトリを作ると大変面倒だったので下記をした
- [GitHubで複数のリポジトリをネストさせる
](https://qiita.com/Statham/items/43da57e6174324d2c68a)

12/31時点. 結局これをやるのがつらいのでコミットできていない

### 色々徒労に終わってつらい
色々手を打ったのが無になったのでかなしい

以降は結局やらなかったけど消すのが悲しかったので残した




## 結局やらないことにしたやつ

容量が大きすぎてpushしたら怒られたので下記のリポジトリに退避してある

(このリポジトリ単体でも実行できる(後述:と思ったらできなかった)、が自分でテストしたい際は該当URL参照)

- [UnityMagic-DownloadResources](https://github.com/kwtkMe/UnityMagic-DownloadResources)
  - gRPCだのMessagePackだのMagicOnionだの
  - そういうリソースのバージョンを固めて置いてある
  
上記を退避しても「./Client/Assets/Plugins/」と「./Client/Client/Libraries/」が重いと言われた(下記)のでやっぱり上記リポジトリからリソースを手動で入れるようにしてください

![怒られ1](https://user-images.githubusercontent.com/42050632/71555063-b5031700-2a6a-11ea-8057-5cf62b228f4f.png)
